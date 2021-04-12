using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.BorrowedBooks.Contracts
{
    public class AddBorrowedBookDto
    {
        public string BookTitle { get; set; }
        public byte MemberAge { get; set; }
        public AgeRange BookAgeRange { get; set; }
        
        public AgeRange MemberAgeRange;
        public AddBorrowedBookDto()
        {
            if (MemberAge >= 1 && MemberAge <= 10)
            {
                MemberAgeRange = AgeRange.oneToTen;
            }
            if (MemberAge >= 10 && MemberAge <= 20)
            {
                MemberAgeRange = AgeRange.tenToTwenty;
            }
            else
            {
                MemberAgeRange = AgeRange.twentyToOlder;
            }
        }
    }
}
