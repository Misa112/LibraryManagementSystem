using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace LibraryManagementSystem.Pages.Books
{
    public class GetAllBooksModel : PageModel
    {
        
            public IEnumerable<Book> Books { get; set; }
            private IBookService bookService;

            public GetAllBooksModel(IBookService bookService)
            {
                this.bookService = bookService;
            }
            public void OnGet()
            {
                Books = bookService.DisplayAllBooks();
            }
        
    }
}
