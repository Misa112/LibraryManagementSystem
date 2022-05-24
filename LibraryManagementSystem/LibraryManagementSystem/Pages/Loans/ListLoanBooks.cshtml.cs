using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.ModelViews;
using LibraryManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryManagementSystem.Pages.Loans
{
    public class ListLoanBooksModel : PageModel
    {
        public IEnumerable<LoanBook> LoanBooks { get; set; }
        private ILoanService loanService;
        public int ID { get; set; }

        


        public ListLoanBooksModel(ILoanService loanService)
        {
            this.loanService = loanService;
        }
        public void OnGet(int id)
        {
            LoanBooks = loanService.LoanBooks(id);
            ID = id;
        }
    }
}
