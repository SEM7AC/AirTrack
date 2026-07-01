using AirTrack.Server.Models.Aircraft;
using AirTrack.Server.Models.Maintenance;
using AirTrack.Server.Models.People;
using AirTrack.Server.Models.Scheduler;
using Microsoft.EntityFrameworkCore;

namespace AirTrack.Server.Data
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

            modelBuilder.Entity<AircraftBase>() // Unique Tailnumber constraint
            .HasIndex(a => a.TailNumber)
            .IsUnique();

            modelBuilder.Entity<AircraftBase>()
                        .HasMany<RecurringAD>()
                        .WithOne(ad => ad.Aircraft)
                        .HasForeignKey(ad => ad.AircraftId)
                        .OnDelete(DeleteBehavior.Cascade);


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
        
        



        // People
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet <Student> Students { get; set; }

        // Scheduler
        public DbSet<FlightEvent> FlightEvents { get; set; }



        }
    }
