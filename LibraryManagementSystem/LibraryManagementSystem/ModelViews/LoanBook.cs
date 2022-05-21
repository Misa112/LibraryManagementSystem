using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.ModelViews
{
    public class LoanBook
    {
        public string ISBN { get; set; }
        public int CopyId { get; set; }
        public string BookName { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
