using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.BorrowedBooks.Contracts
{
    public class AddBorrowedBookDto
    {
        public AddBorrowedBookDto()
        {

        }

        public string BookTitle { get; set; }
        

        private byte theMemberAge;
        public byte MemberAge { 
            get {
                return theMemberAge;
            } 
            set {
                theMemberAge = value;
                SetMemberAgeRange(value);
            } 
        }
        public AgeRange BookAgeRange { get; set; }

        public AgeRange MemberAgeRange;
        
        private void SetMemberAgeRange(byte val)
        {
            if (val >= 1 && val < 10)
            {
                MemberAgeRange = AgeRange.oneToTen;
            }
            if (val >= 10 && val <= 20)
            {
                MemberAgeRange = AgeRange.tenToTwenty;
            }
            if (val > 20)
            {
                MemberAgeRange = AgeRange.twentyToOlder;
            }
        }
    }
}
