using LibraryManagementSystem.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services.Interface
{
    public interface ILoanService
    {
        public IEnumerable<LoanBook> LoanBooks(int id);

        public void ReturnBookLoan(int copyID, int loanFee);

        public int AddLoan(DateTime dateFrom, DateTime dateTo, int userID);
    }
}
