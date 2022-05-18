using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryManagementSystem.Pages.Books
{
    public class ReturnBookModel : PageModel
    {

        public IEnumerable<User> Users { get; set; }
        private IUserService userService;

        public ReturnBookModel(IUserService userService)
        {
            this.userService = userService;
        }
        public void OnGet()
        {
            Users = userService.DisplayUsers();
        }

    }
}
