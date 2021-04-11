using Library.Infrastructure.Test;
using Library.Persistence.EF;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Library.Services.Tests.Spec.BookCategories.Add
{
    public class Successful
    {
        // Given[("فهرست دسته بندی کتاب ها دارای تعداد 0 عدد دسته بندی است")]
        private void Given()
        {
            var db = new EFInMemoryDatabase();
            EFDataContext context = db.CreateDataContext<EFDataContext>();
            int numberOfRecords = context.BookCategories.Count();
            var BookCategoryAppService = new BookCategoryService();
            var sut = new BookCategoryAppService();
        }
        // When[("یک دسته بندی با عنوان کتابهای تاریخی ایجاد میکنم")]
        private void When()
        {

        }
        // Then[("باید فقط یک دسته بندی با عنوان کتابهای تاریخی در فهرست دسته بندی ها موجود باشد")]
        private void Then()
        {

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
