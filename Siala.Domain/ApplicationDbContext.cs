using Siala.Domain.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Siala.Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Constructor

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        #endregion Constructor

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Kill>().ToTable("Kills");
            modelBuilder.Entity<Kill>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Player>().ToTable("Players");
            modelBuilder.Entity<Player>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<InvolvedPlayer>().ToTable("InvolvedPlayers");
            modelBuilder.Entity<InvolvedPlayer>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PlayerClass>().ToTable("PlayerClasses");
            modelBuilder.Entity<PlayerClass>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PlayerRace>().ToTable("PlayerRaces");
            modelBuilder.Entity<PlayerRace>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Faction>().ToTable("Factions");
            modelBuilder.Entity<Faction>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Location>().ToTable("Locations");
            modelBuilder.Entity<Location>().Property(i => i.Id).ValueGeneratedOnAdd();
        }

        #endregion Methods
       
        #region Properties

        public DbSet<Location> Locations { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<PlayerRace> PlayerRaces { get; set; }
        public DbSet<PlayerClass> PlayerClasses { get; set; }
        public DbSet<InvolvedPlayer> InvolvedPlayers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Kill> Kills { get; set; }

        #endregion Properties
    }
}