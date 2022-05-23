using LibraryManagementSystem.Models;
using LibraryManagementSystem.ModelViews;
using LibraryManagementSystem.Services.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services.EFServices
{
    public class EFLoanService : ILoanService
    {

        private LibrarydbContext librarydbContext;
        string connectionString;
        private IConfiguration configuration;

        public EFLoanService(IConfiguration config, LibrarydbContext context)
        {
            librarydbContext = context;
            configuration = config;
            connectionString = configuration.GetConnectionString("Library");
        }

        public int AddLoan(DateTime dateFrom, DateTime dateTo, int userID)
        {
            var loan = new Loan { DateFrom = dateFrom, DateTo = dateTo, Fee = 0, UserId = userID };
            librarydbContext.Add<Loan>(loan);
            librarydbContext.SaveChanges();
            return loan.LoanId;
        }

        public IEnumerable<LoanBook> LoanBooks(int id)
        {

            List<LoanBook> returnList = new List<LoanBook>();
            string query = "select b.ISBN, c.CopyId, b.Title, l.DateFrom, l.DateTo from loans l " +
                "inner join users u on l.userId = u.userID " +
                "inner join copies c on l.LoanId = c.LoanId " +
                "Inner join books b on c.ISBN = b.ISBN " +
               " where c.IsReturned = 0 and u.UserId = " + id;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        LoanBook loanBook = new LoanBook();
                        loanBook.ISBN = Convert.ToString(reader[0]);
                        loanBook.CopyId = Convert.ToInt32(reader[1]);
                        loanBook.BookName = Convert.ToString(reader[2]);
                        loanBook.IssueDate = Convert.ToDateTime(reader[3]);
                        loanBook.ReturnDate = Convert.ToDateTime(reader[4]);
                        returnList.Add(loanBook);
                    }
                }
                return returnList;
            }
        }

        public void ReturnBookLoan(int copyID, int loanFee) {
            var loanId = librarydbContext.Copies.Where(w => w.CopyId == copyID).FirstOrDefault();
            var loan = librarydbContext.Loans.First(f => f.LoanId == loanId.LoanId);
            loan.Fee = loanFee;
            librarydbContext.SaveChanges();
        }
    }
}
