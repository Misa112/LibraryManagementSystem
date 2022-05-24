using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Pages.Books
{
    public class AddBookModel : PageModel
    {
        [BindProperty]
        public IEnumerable<Author> Author { get; set; }

        [BindProperty]
        public int[] Authors { get; set; }

        [BindProperty]
        public Book Book { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }

        private IAuthorService authorService;
        private IWebHostEnvironment _environment;
        private IBookService bookService;
        private ICopyService copyService;
        private IPublicationService publicationService;

        public AddBookModel(IAuthorService authorService, IWebHostEnvironment environment, IBookService bookService, ICopyService copyService, IPublicationService publicationService)
        {
            this.authorService = authorService;
            _environment = environment;
            this.bookService = bookService;
            this.copyService = copyService;
            this.publicationService = publicationService;
            
        }

        public void OnGet()
        {
            Author = authorService.GetAuthors();
           
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                string wwwPath = _environment.WebRootPath;
                string file = Path.Combine(wwwPath, "Image", Upload.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    Upload.CopyToAsync(fileStream);
                }

                bookService.AddBook(Book.Isbn, Book.Title, Book.Description, Book.Genre, Book.Year, Book.NumberOfCopies, Upload.FileName);

                for (var i = 1; i <= Book.NumberOfCopies; i++)
                {
                    copyService.AddCopy(Book.Isbn);
                }

                for (var i = 0; i < Authors.Length; i++)
                {
                    publicationService.AddPublication(Book.Isbn, Authors[i]);
                }
                ViewData["Success"] = "Data has been successfully Inserted.";
            } catch (Exception e)
            {
                ViewData["Error"] = "Data Could not be inserted. " + e.Message;
            }
            return RedirectToPage("/Books/GetAllBooks");
        }
    }
}
