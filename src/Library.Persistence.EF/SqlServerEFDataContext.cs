using Library.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Library.Persistence.EF
{
    public class SqlServerEFDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=Library;trusted_connection=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; protected set; }
        public DbSet<BookCategory> BookCategories { get; protected set; }
        public DbSet<Writer> Writers { get; protected set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; protected set; }
        public DbSet<Member> Members { get; protected set; }
    }
}
