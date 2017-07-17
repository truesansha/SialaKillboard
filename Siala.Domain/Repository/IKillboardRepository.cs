using System.Collections.Generic;
using Siala.Domain.DataModels;

namespace Siala.Domain.Repository
{
    public interface IKillboardRepository
    {
        IEnumerable<Kill> Kills { get; }
    }
}