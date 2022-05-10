using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace LibraryManagementSystem.Pages.Genre
{
    public class GetGenresModel : PageModel
    {
        

        public List<string> Genres{ get; set; }

        private IBookService bookService;

        public GetGenresModel(IBookService bookService)
        {
            this.bookService = bookService;
        }
        public void OnGet()
        {

            Genres = bookService.GetDistinctGenre();


        }
    }
}
