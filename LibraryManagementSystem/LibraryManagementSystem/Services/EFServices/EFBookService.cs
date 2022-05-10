using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services.EFServices
{
    public class EFBookService : IBookService
    {

        private LibrarydbContext librarydbContext;

        public EFBookService(LibrarydbContext context)
        {
            librarydbContext = context;
        }
        public IEnumerable<Book> DisplayAllBooks()
        {
            return librarydbContext.Books;
        }

        public List<string> GetDistinctGenre()
        {
            return librarydbContext.Books.Select(book => book.Genre).Distinct().ToList();
        }

    }
}
