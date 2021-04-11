using Library.Infrastructure.Test;
using Library.Persistence.EF;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Library.Services.BookCategories;
using Library.Persistence.EF.BookCategories;
using Library.Services.BookCategories.Contracts;
using FluentAssertions;

namespace Library.Services.Tests.Spec.BookCategories.Add
{
    public class Successful
    {
        private EFInMemoryDatabase db;
        private EFBookCategoryRepository efBookCategoryRepository;
        private EFUnitOfWork efUnitOfWork;
        private BookCategoryAppService sut;
        private EFDataContext context;
        public Successful()
        {
            db = new EFInMemoryDatabase();
            context = db.CreateDataContext<EFDataContext>();
            efBookCategoryRepository = new EFBookCategoryRepository(context);
            efUnitOfWork = new EFUnitOfWork(context);
            sut = new BookCategoryAppService(efBookCategoryRepository, efUnitOfWork);
        }
        // Given[("فهرست دسته بندی کتاب ها خالی است")]
        private void Given()
        {
        }
        // When[("یک دسته بندی با عنوان کتابهای تاریخی ایجاد میکنم")]
        private void When()
        {
            var bookCategoryDto = new AddBookCategoryDto() {
                Title = "کتابهای تاریخی"
            };
            sut.Add(bookCategoryDto);
        }
        // Then[("باید فقط یک دسته بندی با عنوان کتابهای تاریخی در فهرست دسته بندی ها موجود باشد")]
        private void Then()
        {
            var listOfBookCategories = context.BookCategories.ToList();
            listOfBookCategories.Should().HaveCount(1);
            listOfBookCategories.Should().Contain(_=>_.Title== "کتابهای تاریخی");
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
