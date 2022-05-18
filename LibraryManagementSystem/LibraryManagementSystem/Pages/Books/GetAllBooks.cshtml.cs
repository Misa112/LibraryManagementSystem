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

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public GetAllBooksModel(IBookService bookService)
        {
            this.bookService = bookService;
        }
        public IActionResult OnGet()
        {
            Books = bookService.DisplayAllBooks();

            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Books = bookService.FilterBook(FilterCriteria);
            }
            return Page();
        }
    }
}
