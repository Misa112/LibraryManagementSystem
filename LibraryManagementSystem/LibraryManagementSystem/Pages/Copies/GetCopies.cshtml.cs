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
    public class GetCopiesModel : PageModel
    {
        public IEnumerable<Copy> Copies { get; set; }
        public string Title { get; set; }

        private ICopyService copyService;

        public GetCopiesModel(ICopyService copyService)
        {
            this.copyService = copyService;
        }
        public void OnGet(string id, string title)
        {
            Copies = copyService.DisplayCopies(id);
            Title = title;
        }
    }
}
