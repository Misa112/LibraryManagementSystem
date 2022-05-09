using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interface;
using System.Collections.Generic;

namespace LibraryManagementSystem.Services.EFServices
{
    public class EFAuthorService:IAuthorService
    {
        private LibrarydbContext librarydbContext;

        public EFAuthorService(LibrarydbContext context)
        {
            librarydbContext = context;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return librarydbContext.Authors;
        }
    }
}
