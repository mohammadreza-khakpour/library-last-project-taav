using System;

namespace Library.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
        public AgeRange AgeRange { get; set; }
        public int CategoryId { get; set; }
        public virtual BookCategory Category { get; set; }


    }
}
