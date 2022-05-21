using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryManagementSystem.Pages.Copies
{
    public class ReturnCopyModel : PageModel
    {
        [BindProperty] 
        public int ID { get; set; }

        public DateTime ReturnDate { get; set; }

        public Loan Loan { get; set; }
        [BindProperty]
        public Copy Copy { get; set; }

        [BindProperty]
        public Book Book { get; set; }

        [BindProperty]
        public int LoanFee { get; set; }

        private ICopyService copyService;
        private IBookService bookService;
        private ILoanService loanService;


        public ReturnCopyModel(ICopyService copyService, IBookService bookService, ILoanService loanService)
        {
            this.copyService = copyService;
            this.bookService = bookService;
            this.loanService = loanService;

        }
        public void OnGet(int copyID, string ISBN, int Id, DateTime dateTo)
        {
            Copy = copyService.DisplayACopies(copyID);
            Book = bookService.GetBookByISBN(ISBN);
            ID = Id;
            ReturnDate = dateTo;
        }

        public IActionResult OnPost()
        {
            loanService.ReturnBookLoan(Copy.CopyId, LoanFee);
            copyService.ReturnCopy(Copy.CopyId);
            bookService.ReturnBook(Book.Isbn);
            return RedirectToPage("/Loans/ListLoanBooks",null, new { id = ID });
            //return RedirectToPage("/Loans/ListLoanBooks?id="+ ID);
        }
    }
}
