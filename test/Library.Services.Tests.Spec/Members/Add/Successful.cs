using FluentAssertions;
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

namespace Library.Services.Tests.Spec.Members.Add
{
    public class Successful
    {
        private EFInMemoryDatabase db;
        private EFMemberRepository efMemberRepository;
        private EFUnitOfWork efUnitOfWork;
        private MemberAppService sut;
        private EFDataContext context;
        private int actualRecordId;
        public Successful()
        {
            db = new EFInMemoryDatabase();
            context = db.CreateDataContext<EFDataContext>();
            efMemberRepository = new EFMemberRepository(context);
            efUnitOfWork = new EFUnitOfWork(context);
            sut = new MemberAppService(efMemberRepository, efUnitOfWork);
        }
        // Given[("فهرست اعضای کتابخانه خالی است")]
        private void Given()
        {
        }
        // When[("یک عضو با سن 20 سال تعریف میکنم")]
        private void When()
        {
            AddMemberDto dto = new AddMemberDto() { 
                Age = 20
            };
            actualRecordId = sut.Add(dto);
        }
        // Then[("باید تنها یک عضو با سن 20 در فهرست اعضا موجود باشد")]
        private void Then()
        {
            var expected = context.Members.ToList();
            expected.Should().HaveCount(1);
            var expectedRecord = context.Members.Single(_=>_.Id==actualRecordId);
            expected.Should().Contain(_=>_.Age==expectedRecord.Age);
        }
        [Fact]
        public void Run()
        {
            Given();
            When();
            Then();
        }
    }
}
