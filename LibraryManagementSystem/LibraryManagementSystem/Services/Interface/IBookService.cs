﻿using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services.Interface
{
    public interface IBookService
    {
        IEnumerable<Book> DisplayAllBooks();

        IEnumerable<string> GetOneGenre();

    }
}
