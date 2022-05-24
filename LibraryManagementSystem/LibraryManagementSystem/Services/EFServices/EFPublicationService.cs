using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services.EFServices
{
    public class EFPublicationService : IPublicationService
    {
        private LibrarydbContext librarydbContext;

        public EFPublicationService(LibrarydbContext context)
        {
            librarydbContext = context;
        }

        public void AddPublication(string Isbn, int authorID)
        {
            var publication = new Publication { Isbn = Isbn, AuthorId = authorID };
            librarydbContext.Add<Publication>(publication);
            librarydbContext.SaveChanges();
        }
    }
}
