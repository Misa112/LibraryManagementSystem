using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services.Interface
{
    public interface IBookService
    {
        IEnumerable<Book> DisplayAllBooks();

        List<string> GetDistinctGenre();
        List<Book> FilterBook(string criteria);


        public void DeleteBook(string isbn);

        Book GetBook(string  isbn);

        public bool CheckLoan(string isbn);

    }
}
