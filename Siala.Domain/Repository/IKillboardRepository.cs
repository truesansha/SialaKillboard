using System.Collections.Generic;
using Siala.Domain.DataModels;

namespace Siala.Domain.Repository
{
    public interface IKillboardRepository
    {
        IEnumerable<Kill> Kills { get; }
        IEnumerable<Player> Players { get; }
        IEnumerable<PlayerClass> PlayerClasses { get; }
        IEnumerable<Faction> Factions { get; }
        IEnumerable<Location> Locations { get; }
    }
}