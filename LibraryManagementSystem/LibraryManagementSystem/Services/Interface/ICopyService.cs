using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services.Interface
{
    public interface ICopyService
    {
        IEnumerable<Copy> DisplayCopies(string id);

        public Copy DisplayACopies(int id);

        public void ReturnCopy(int copyID);

        public void LoanCopy(int copyID, int loanID);

        public void AddCopy(string ISBN);
    }
}
