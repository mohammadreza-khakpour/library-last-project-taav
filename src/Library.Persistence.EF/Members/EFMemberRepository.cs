using Library.Entities;
using Library.Services.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Persistence.EF.Members
{
    public class EFMemberRepository : MemberRepository
    {
        private EFDataContext _dBContext;
        public EFMemberRepository(EFDataContext dBContext)
        {
            _dBContext = dBContext;
        }
        public void Add(Member member)
        {
            _dBContext.Members.Add(member);
        }
    }
}
