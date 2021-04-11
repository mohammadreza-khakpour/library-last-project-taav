using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace Library.Persistence.EF
{
    public class EFDataContext : DbContext
    {
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
