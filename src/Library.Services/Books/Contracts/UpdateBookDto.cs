using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Books.Contracts
{
    public class UpdateBookDto
    {
        public string Title { get; set; }
        public AgeRange AgeRange { get; set; }
        public int CategoryId { get; set; }
        public int WriterId { get; set; }

    }
}
