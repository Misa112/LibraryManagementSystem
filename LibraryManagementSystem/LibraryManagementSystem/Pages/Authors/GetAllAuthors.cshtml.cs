using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace LibraryManagementSystem.Pages.Books
{
    public class GetAllAuthorsModel : PageModel
    {
        public IEnumerable<Author> Authors { get; set; }


        private IAuthorService authorService;

        public GetAllAuthorsModel(IAuthorService authorService)
        {

            this.authorService = authorService;
        }
        public void OnGet()
        {
            Authors = authorService.GetAuthors();
        }
    }
}
