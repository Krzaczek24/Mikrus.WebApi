using Krzaq.Mikrus.Database.Entities.Friend;
using Krzaq.Mikrus.Database.Entities.Game;
using Krzaq.Mikrus.Database.Entities.Room;
using Krzaq.Mikrus.Database.Entities.RoomChat;
using Krzaq.Mikrus.Database.Entities.User;
using Krzaq.Mikrus.Database.Entities.UserStats;
using Microsoft.EntityFrameworkCore;

namespace Krzaq.Mikrus.Database
{
    internal class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public virtual DbSet<DbFriend> Friends { get; set; }
        public virtual DbSet<DbGame> Games { get; set; }
        public virtual DbSet<DbRoom> Rooms { get; set; }
        public virtual DbSet<DbRoomChat> RoomChats { get; set; }
        public virtual DbSet<DbUser> Users { get; set; }
        public virtual DbSet<DbUserStats> UserStats { get; set; }

        //public override sealed int SaveChanges()
        //{
        //    ValidateAndSetModifDate();
        //    return base.SaveChanges();
        //}

        //public override sealed Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    ValidateAndSetModifDate();
        //    return base.SaveChangesAsync(cancellationToken);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        //private void ValidateAndSetModifDate()
        //{
        //    DbTable entity;

        //    foreach (var entityEntry in ChangeTracker.Entries().Where(e => e.Entity is DbTable))
        //    {
        //        entity = (DbTable)entityEntry.Entity;

        //        switch (entityEntry.State)
        //        {
        //            case EntityState.Modified:
        //                //if (entity.Active.HasValue && !entity.Active.Value)
        //                //    throw new InvalidOperationException("Cannot modify inactive records");
        //                foreach (string member in DbTableCommonModel.UnmodifiableMembers)
        //                    if (entityEntry.Member(member).IsModified)
        //                        throw new InvalidOperationException($"Cannot modify '{member}' member");
        //                entity.ModifDate = DateTime.Now;
        //                break;
        //                //case EntityState.Deleted:
        //                //    entity.Active = false;
        //                //    entity.ModifDate = DateTime.Now;
        //                //    break;
        //        }
        //    }
        //}
    }
}
