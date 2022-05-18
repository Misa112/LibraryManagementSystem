using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryManagementSystem.Pages.Books
{
    public class DeleteBookModel : PageModel
    {
        [BindProperty]
        public Book Books { get; set; }
        public bool IsLoaned { get; set; }

        private IBookService bookService;

        public DeleteBookModel(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public void OnGet(string isbn)
        {
            Books = bookService.GetBook(isbn);
            IsLoaned = bookService.CheckLoan(isbn);
        }
        
        public void OnPost()
        {
            bookService.DeleteBook(Books.Isbn);
            Response.Redirect("/Books/GetAllBooks");
        }

    }
}
