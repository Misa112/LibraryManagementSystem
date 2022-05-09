
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace LibraryManagementSystem.Services.Interface

{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAuthors();  
    }
}
