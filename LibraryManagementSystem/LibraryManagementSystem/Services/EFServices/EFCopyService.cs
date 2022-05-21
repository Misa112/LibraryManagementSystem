using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services.EFServices
{
    public class EFCopyService : ICopyService
    {
        private LibrarydbContext librarydbContext;

        public EFCopyService(LibrarydbContext context)
        {
            librarydbContext = context;
        }
        public IEnumerable<Copy> DisplayCopies(string id)
        {
            return librarydbContext.Copies.Where(w => w.Isbn == id && w.IsReturned == true).Select(s => s);
        }

        public Copy DisplayACopies(int id)
        {
            return librarydbContext.Copies.Where(w => w.CopyId == id).FirstOrDefault();
        }

        public void ReturnCopy(int copyID) {
            var copy = librarydbContext.Copies.First(a => a.CopyId == copyID);
            copy.IsReturned = true;
            copy.LoanId = null;
            librarydbContext.SaveChanges();
        }
    }
}
