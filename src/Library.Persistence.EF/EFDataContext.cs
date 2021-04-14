using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Reflection;

namespace Library.Persistence.EF
{
    public class EFDataContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.;database=Library;trusted_connection=true");
        //    base.OnConfiguring(optionsBuilder);
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //    base.OnModelCreating(modelBuilder);
        //}
        //public DbSet<Book> Books { get; protected set; }
        //public DbSet<BookCategory> BookCategories { get; protected set; }
        //public DbSet<Writer> Writers { get; protected set; }
        //public DbSet<BorrowedBook> BorrowedBooks { get; protected set; }
        //public DbSet<Member> Members { get; protected set; }



        //////////////////////////////// to test with sqLite, uncomment these ////////////////////////////////////
        //////////////////////////////// and comment the above section //////////////////////////////////////////

        public DbSet<Book> Books { get; protected set; }
        public DbSet<BookCategory> BookCategories { get; protected set; }
        public DbSet<Writer> Writers { get; protected set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; protected set; }
        public DbSet<Member> Members { get; protected set; }

        public EFDataContext(string connectionString)
            : this(new DbContextOptionsBuilder<EFDataContext>().UseSqlite(connectionString).Options)
        {
        }

        private EFDataContext(DbContextOptions<EFDataContext> options)
            : this((DbContextOptions)options)
        {
        }

        protected EFDataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);
        }

        public override ChangeTracker ChangeTracker
        {
            get
            {
                var tracker = base.ChangeTracker;
                tracker.LazyLoadingEnabled = false;
                tracker.AutoDetectChangesEnabled = true;
                tracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
                return tracker;
            }
        }
    }
}
