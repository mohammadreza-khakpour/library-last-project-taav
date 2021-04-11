using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Members.Contracts
{
    public class AddMemberDto
    {
        public string Fullname { get; set; }
        public byte Age { get; set; }
        public string Address { get; set; }
    }
}
