using System.Collections.Generic;
using Siala.Domain.DataModels;

namespace Siala.Domain.Repository
{
    public class KillboardRepository : IKillboardRepository
    {
        public IEnumerable<Kill> Kills => new List<Kill>();
    }
}