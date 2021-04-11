using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Books.Contracts
{
    public class AddBookDto
    {
        public string Title { get; set; }
        public int WriterId { get; set; }
        public AgeRange AgeRange { get; set; }
        public int CategoryId { get; set; }
    }
}
