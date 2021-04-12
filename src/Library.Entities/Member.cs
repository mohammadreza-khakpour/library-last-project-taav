using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public byte Age { get; set; }
        
        //private AgeRange ageRange;

        //public AgeRange AgeRange
        //{
        //    get {
        //        return ageRange;
        //    }
        //    set {
        //        if (Age >= 1 && Age <= 10)
        //        {
        //            ageRange = AgeRange.oneToTen;
        //        }
        //        if (Age >= 10 && Age <= 20)
        //        {
        //            ageRange = AgeRange.tenToTwenty;
        //        }
        //        else
        //        {
        //            ageRange = AgeRange.twentyToOlder;
        //        }
        //    }
        //}

        public string Address { get; set; }

    }
}
