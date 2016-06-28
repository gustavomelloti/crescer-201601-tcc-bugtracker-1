﻿using BugTracker.Domain.Entity;
using BugTracker.Infra.Repository.Map;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Dominio = BugTracker.Domain.Entity;

namespace BugTracker.Infra.Repository
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Conn"){ }

        public DbSet<User> User { get; set; }
        public DbSet<UserRecovery> UserRecovery { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<Dominio.BugTracker> BugTrucker { get; set; }
        public DbSet<BugTrackerNavigation> BugTrackerNavigation { get; set; }
        public DbSet<BugTrackerTag> BugTrackerTag { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
             .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserRecoveryMap());
            modelBuilder.Configurations.Add(new ApplicationMap());
            modelBuilder.Configurations.Add(new BugTrackerMap());
            modelBuilder.Configurations.Add(new BugTrackerNavigationMap());
            modelBuilder.Configurations.Add(new BugTrackerTagMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
