using FluentAssertions;
using Library.Infrastructure.Application;
using Library.Infrastructure.Test;
using Library.Persistence.EF;
using Library.Persistence.EF.Members;
using Library.Services.Members;
using Library.Services.Members.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Library.Services.Tests.Unit.Members
{
    public class MemberServiceTests
    {
        private MemberService sut;
        private MemberRepository _memberRepository;
        private UnitOfWork _unitOfWork;
        private EFDataContext context;
        private EFDataContext readContext;
        public MemberServiceTests()
        {
            var db = new EFInMemoryDatabase();
            context = db.CreateDataContext<EFDataContext>();
            readContext = db.CreateDataContext<EFDataContext>();
            _memberRepository = new EFMemberRepository(context);
            _unitOfWork = new EFUnitOfWork(context);
            sut = new MemberAppService(_memberRepository, _unitOfWork);
        }
        [Fact]
        public void Add_add_member_properly()
        {
            //Arrange
            AddMemberDto dto = new AddMemberDto()
            {
                Fullname = "dummy-name",
                Address = "dummy-address",
                Age = 1
            };

            //Act
            var actualReturnedId = sut.Add(dto);

            //Assert
            var expected = readContext.Members.Single(_ => _.Id == actualReturnedId);
            expected.Age.Should().Be(1);
            expected.Address.Should().Be("dummy-address");
            expected.Fullname.Should().Be("dummy-name");
        }
    }
}
