namespace BusWeb.Data.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BusWebModel : DbContext
    {
        public BusWebModel()
            : base("name=BusWebModel")
        {
        }

        public virtual DbSet<CITY> CITies { get; set; }
        public virtual DbSet<ROUTE> ROUTEs { get; set; }
        public virtual DbSet<ROUTE_TYPE> ROUTE_TYPE { get; set; }
        public virtual DbSet<STATION> STATIONs { get; set; }
        public virtual DbSet<SYSADM_USER> SYSADM_USER { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CITY>()
                .Property(e => e.CITY_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<CITY>()
                .HasMany(e => e.ROUTEs)
                .WithRequired(e => e.CITY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROUTE>()
                .Property(e => e.ROUTE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTE>()
                .Property(e => e.VEHICLE_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTE>()
                .HasMany(e => e.STATIONs)
                .WithRequired(e => e.ROUTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROUTE_TYPE>()
                .Property(e => e.ROUTE_TYPE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTE_TYPE>()
                .HasMany(e => e.ROUTEs)
                .WithRequired(e => e.ROUTE_TYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STATION>()
                .Property(e => e.STATION_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<STATION>()
                .Property(e => e.ARRIVAL_TIME)
                .IsUnicode(false);

            modelBuilder.Entity<STATION>()
                .Property(e => e.DEPARTURE_TIME)
                .IsUnicode(false);

            modelBuilder.Entity<SYSADM_USER>()
                .Property(e => e.FIRST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SYSADM_USER>()
                .Property(e => e.LAST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SYSADM_USER>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<SYSADM_USER>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<SYSADM_USER>()
                .HasMany(e => e.CITies)
                .WithRequired(e => e.SYSADM_USER)
                .HasForeignKey(e => e.CREATE_UID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SYSADM_USER>()
                .HasMany(e => e.CITies1)
                .WithRequired(e => e.SYSADM_USER1)
                .HasForeignKey(e => e.LASTUPD_UID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SYSADM_USER>()
                .HasMany(e => e.ROUTEs)
                .WithRequired(e => e.SYSADM_USER)
                .HasForeignKey(e => e.CREATE_UID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SYSADM_USER>()
                .HasMany(e => e.ROUTEs1)
                .WithRequired(e => e.SYSADM_USER1)
                .HasForeignKey(e => e.LASTUPD_UID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SYSADM_USER>()
                .HasMany(e => e.ROUTE_TYPE)
                .WithRequired(e => e.SYSADM_USER)
                .HasForeignKey(e => e.CREATE_UID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SYSADM_USER>()
                .HasMany(e => e.ROUTE_TYPE1)
                .WithRequired(e => e.SYSADM_USER1)
                .HasForeignKey(e => e.LASTUPD_UID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SYSADM_USER>()
                .HasMany(e => e.STATIONs)
                .WithRequired(e => e.SYSADM_USER)
                .HasForeignKey(e => e.CREATE_UID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SYSADM_USER>()
                .HasMany(e => e.STATIONs1)
                .WithRequired(e => e.SYSADM_USER1)
                .HasForeignKey(e => e.LASTUPD_UID)
                .WillCascadeOnDelete(false);
        }
    }
}
