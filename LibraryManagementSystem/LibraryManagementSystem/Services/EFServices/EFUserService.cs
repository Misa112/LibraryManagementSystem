using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services.EFServices
{
    public class EFUserService : IUserService
    {
        private LibrarydbContext librarydbContext;

        public EFUserService(LibrarydbContext context)
        {
            librarydbContext = context;
        }

        public IEnumerable<User> DisplayUsers()
        {
            return librarydbContext.Users.Where(a => a.IsAdmin == false);
        }
    }
}
