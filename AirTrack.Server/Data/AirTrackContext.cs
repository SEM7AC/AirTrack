using AirTrack.Model.Aircraft;
using AirTrack.Models.Maintenance;
using AirTrack.Models.People;
using Microsoft.EntityFrameworkCore;

namespace AirTrack.Data
    {
    public class AirTrackContext : DbContext
        {
        public AirTrackContext(DbContextOptions<AirTrackContext> options)
            : base(options)
            {
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            // TPT mapping
            modelBuilder.Entity<AircraftBase>().ToTable("Aircraft");

            modelBuilder.Entity<CessnaSkyhawk>().ToTable("CessnaSkyhawks");
            modelBuilder.Entity<PiperArrow>().ToTable("PiperArrows");
            modelBuilder.Entity<PiperSeminole>().ToTable("PiperSeminoles");
            modelBuilder.Entity<RobinsonR44>().ToTable("RobinsonR44s");

            base.OnModelCreating(modelBuilder);
            }

        // Aircraft Base

        public DbSet<AircraftBase> AircraftBases { get; set; }

        // Aircraft
        public DbSet<CessnaSkyhawk> CessnaSkyhawks { get; set; }
        public DbSet<PiperArrow> PiperArrows { get; set; }
        public DbSet<PiperSeminole> PiperSeminoles { get; set; }
        public DbSet<RobinsonR44> RobinsonR44s { get; set; }
        public DbSet<RecurringAD> RecurringADs { get; set; }

        // Maintenance
        public DbSet<Squawk> Squawks { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<CorrectiveAction> CorrectiveActions { get; set; }
        public DbSet<MechanicSignoff> MechanicSignoffs { get; set; }



        // People
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet <Student> Students { get; set; }


        }
    }
