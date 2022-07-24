using BlazorSozluk.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace BlazorSozluk.Infrastructure.Persistance.Context
{
    public class BlazerSozlukContext:DbContext
    {
        public const string DEFAULT_SCHEMA = "dbo";

        public BlazerSozlukContext()
        {

        }
        public BlazerSozlukContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<EntryComment> EnrtyComments { get; set; }
        public DbSet<EntryCommentVote> EnrtyCommentVotes { get; set; }
        public DbSet<EntryFavorite> EnrtyFavorites { get; set; }
        public DbSet<EmailConfirmation> EmailConfirmations { get; set; }
        public DbSet<EntryFavorite> EntryFavorites { get; set; }
        public DbSet<EntryCommentFavorite> EntryCommentFavorites { get; set; }
        public DbSet<EntryVote> EnrtyVotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = "Server=localhost;Database=master;Trusted_Connection=True;";
                optionsBuilder.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnBeforeSave();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSave()
        {
            var addedEntities = ChangeTracker.Entries()
                .Where(i=>i.State == EntityState.Added)
                .Select(i=>(BaseEntity)i.Entity);
            PrepareAddedEntities(addedEntities);
        }

        private void PrepareAddedEntities(IEnumerable<BaseEntity> entites)
        {
            foreach (var entity in entites)
            {
                if(entity.CreateDate == DateTime.MinValue)
                    entity.CreateDate = DateTime.Now;
            }
        }
    }
}
