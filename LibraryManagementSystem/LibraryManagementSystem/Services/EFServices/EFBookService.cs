using LibraryManagementSystem.Models;
using LibraryManagementSystem.Pages.Books;
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

        public void DeleteBook(string isbn)
        {
           

            Book book = librarydbContext.Books.Where(b=>b.Isbn ==isbn).FirstOrDefault();
            librarydbContext.Books.Remove(book);
            librarydbContext.SaveChanges();
        }

        public IEnumerable<Book> DisplayAllBooks()
        {
            return librarydbContext.Books;
        }

        public Book GetBook(string isbn)
        {
            return librarydbContext.Books.Where(book => book.Isbn == isbn).FirstOrDefault();
        }

        public List<string> GetDistinctGenre()
        {
            return librarydbContext.Books.Select(book => book.Genre).Distinct().ToList();
        }


        public bool CheckLoan(string isbn)
        {


            foreach (var copy in librarydbContext.Copies.Where(book => book.Isbn == isbn))
            {
                if (copy.IsReturned == false)
                {
                    return true;
                }
               
            }

            return false;

           
        }

        public Book GetBookByISBN(string ISBN)
        {
            return librarydbContext.Books.Where(w => w.Isbn == ISBN).FirstOrDefault();
        }

        public List<Book> FilterBook(string criteria)
        {
            return librarydbContext.Books.Where(book => book.Title.Contains(criteria)).ToList();
        }

        public void ReturnBook(string ISBN) {
            var countCopies = librarydbContext.Copies.Where(w => w.Isbn == ISBN && w.IsReturned == true).Count();
            var book = librarydbContext.Books.Where(w => w.Isbn == ISBN).FirstOrDefault();
            book.NumberOfCopies = countCopies;
            if(countCopies > 0)
            {
                book.IsAvailable = true;
            }
            else
            {
                book.IsAvailable = false;
            }
            librarydbContext.SaveChanges();
        }
    }
}
