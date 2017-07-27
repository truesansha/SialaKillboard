using System.Collections.Generic;
using Siala.Domain.DataModels;

namespace Siala.Domain.Repository
{
    public class KillboardRepository : IKillboardRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public KillboardRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Kill> Kills => _dbContext.Kills;
        public IEnumerable<Player> Players => _dbContext.Players;
        public IEnumerable<PlayerClass> PlayerClasses => _dbContext.PlayerClasses;
        public IEnumerable<Faction> Factions => _dbContext.Factions;
        public IEnumerable<Location> Locations => _dbContext.Locations;
        public IEnumerable<PlayerRace> Races => _dbContext.PlayerRaces;
        public IEnumerable<InvolvedPlayer> InvolvedPlayes => _dbContext.InvolvedPlayers;
    }
}