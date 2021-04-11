using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities
{
    public class BorrowedBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
