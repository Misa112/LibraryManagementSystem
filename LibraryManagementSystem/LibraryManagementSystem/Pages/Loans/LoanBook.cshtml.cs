using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryManagementSystem.Pages.Loans
{
    public class LoanBookModel : PageModel
    {
        [BindProperty]
        public Copy Copy { get; set; }
        [BindProperty]
        public Book Book { get; set; }
        [BindProperty]
        public Loan Loan { get; set; }

        public IEnumerable<User> User { get; set; }

        private ICopyService copyService;
        private IBookService bookService;
        private ILoanService loanService;
        private IUserService userService;

        public LoanBookModel(ICopyService copyService, IBookService bookService, ILoanService loanService, IUserService userService)
        {
            this.copyService = copyService;
            this.bookService = bookService;
            this.loanService = loanService;
            this.userService = userService;
        }

        public void OnGet(int copyid)
        {
            Copy = copyService.DisplayACopies(copyid);
            Book = bookService.GetBookByISBN(Copy.Isbn);
            User = userService.DisplayUsers();
        }

        public IActionResult OnPost()
        {
            var loanID = loanService.AddLoan(Loan.DateFrom, Loan.DateTo, Loan.UserId);
            copyService.LoanCopy(Copy.CopyId, loanID);
            bookService.LoanBook(Copy.Isbn);
            return RedirectToPage("/Copies/GetCopies", null, new {title = Book.Title, id = Copy.Isbn });
        }
    }
}
