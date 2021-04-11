using Library.Entities;
using Library.Infrastructure.Application;
using Library.Services.Members.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Members
{
    public class MemberAppService : MemberService
    {
        private readonly MemberRepository _memberRepository;
        private readonly UnitOfWork _unitOfWork;
        public MemberAppService(MemberRepository memberRepository,
                                      UnitOfWork unitOfWork)
        {
            _memberRepository = memberRepository;
            _unitOfWork = unitOfWork;
        }
        public int Add(AddMemberDto dto)
        {
            Member member = new Member()
            {
                Address = dto.Address,
                Age = dto.Age,
                Fullname = dto.Fullname
            };
            _memberRepository.Add(member);
            _unitOfWork.Complete();
            return member.Id;
        }
    }
}
