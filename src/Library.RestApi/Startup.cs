using Library.Infrastructure.Application;
using Library.Persistence.EF;
using Library.Persistence.EF.BookCategories;
using Library.Persistence.EF.Books;
using Library.Persistence.EF.BorrowedBooks;
using Library.Persistence.EF.Members;
using Library.Services.BookCategories;
using Library.Services.BookCategories.Contracts;
using Library.Services.Books;
using Library.Services.Books.Contracts;
using Library.Services.BorrowedBooks;
using Library.Services.Members;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<BookService, BookAppService>();
            services.AddSingleton<BookCategoryService, BookCategoryAppService>();
            services.AddSingleton<MemberService, MemberAppService>();
            services.AddSingleton<BorrowedBookService, BorrowedBookAppService>();
            
            services.AddSingleton<BookRepository, EFBookRepository>();
            services.AddSingleton<BookCategoryRepository, EFBookCategoryRepository>();
            services.AddSingleton<MemberRepository, EFMemberRepository>();
            services.AddSingleton<BorrowedBookRepository, EFBorrowedBookRepository>();

            services.AddSingleton<EFDataContext>();

            services.AddSingleton<UnitOfWork, EFUnitOfWork>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
