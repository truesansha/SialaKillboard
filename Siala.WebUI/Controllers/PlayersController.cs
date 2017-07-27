using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Siala.Domain.Repository;
using Siala.WebUI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Siala.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : BaseController
    {

        // GET api/values/5
        public PlayersController(IKillboardRepository repository) : base(repository)
        {
        }

        [HttpGet("{id}")]
        public PlayerDetailsItem Get(Int32 id)
        {
            PlayerDetailsItem playerDetails = (from p in Repository.Players
                    where p.Id == id
                    join f in Repository.Factions on p.FactionId equals f.Id
                    join r in Repository.Races on p.RaceId equals r.Id
                    join c1 in Repository.PlayerClasses on p.Class1Id equals c1.Id
                    join c2 in Repository.PlayerClasses on p.Class2Id ?? 0 equals c2.Id into ac2L
                    from c2 in ac2L.DefaultIfEmpty()
                    join c3 in Repository.PlayerClasses on p.Class3Id ?? 0 equals c3.Id into ac3L
                    from c3 in ac2L.DefaultIfEmpty()
                    select new PlayerDetailsItem
                    {
                        Id = p.Id,
                        Name = p.Name,
                        RaceId = p.RaceId,
                        Race = r.Name,
                        Class1Id = p.Class1Id,
                        Class2Id = p.Class2Id ?? 0,
                        Class3Id = p.Class3Id ?? 0,
                        Class1 = c1.Name,
                        Class2 = c2?.Name,
                        Class3 = c3?.Name,
                        Class1Level = p.Class1Level,
                        Class2Level = p.Class2Level ?? 0,
                        Class3Level = p.Class3Level ?? 0,
                        FactionId = p.FactionId,
                        Faction = f.Name
                    }).FirstOrDefault();

            if (playerDetails != null)
            {
                playerDetails.TotalKills = Repository.Kills.Count(k => k.FinalBlowPlayerId == id);
                playerDetails.TotalDeaths = Repository.Kills.Count(k => k.VictimId == id);
            }

            return playerDetails;
        }

        [HttpGet("PlayerKills/{playerId}/{page}")]
        public IEnumerable<KillItem> PlayerKills(Int32 playerId, Int32 page)
        {
            return (from k in Repository.Kills
                    where k.FinalBlowPlayerId == playerId
                    join v in Repository.Players on k.VictimId equals v.Id
                    join vc in Repository.PlayerClasses on k.VictimClass1Id equals vc.Id
                    join vf in Repository.Factions on k.VictimFactionId equals vf.Id
                    join kl in Repository.Players on k.FinalBlowPlayerId equals kl.Id
                    join l in Repository.Locations on k.LocationId equals l.Id
                    orderby k.KillTime descending
                    select new KillItem
                    {
                        KillTime = k.KillTime,
                        VictimFactionId = (byte)vf.Id,
                        KillId = k.Id,
                        VictimFaction = vf.Name,
                        KillerName = kl.Name,
                        KillerId = kl.Id,
                        LocationName = l.Name,
                        LocationId = l.Id,
                        VictimClass = vc.Name,
                        VictimName = v.Name,
                        VictimId = v.Id,
                        VictimClassId = k.VictimClass1Id
                    }).Skip((page - 1) * DefaultPageSize).Take(DefaultPageSize);
        }

        [HttpGet("PlayerDeaths/{playerId}/{page}")]
        public IEnumerable<KillItem> PlayerDeaths(Int32 playerId, Int32 page)
        {
            return (from k in Repository.Kills
                    where k.VictimId == playerId
                    join v in Repository.Players on k.VictimId equals v.Id
                    join vc in Repository.PlayerClasses on k.VictimClass1Id equals vc.Id
                    join vf in Repository.Factions on k.VictimFactionId equals vf.Id
                    join kl in Repository.Players on k.FinalBlowPlayerId equals kl.Id
                    join l in Repository.Locations on k.LocationId equals l.Id
                    orderby k.KillTime descending
                    select new KillItem
                    {
                        KillTime = k.KillTime,
                        VictimFactionId = (byte)vf.Id,
                        KillId = k.Id,
                        VictimFaction = vf.Name,
                        KillerName = kl.Name,
                        KillerId = kl.Id,
                        LocationName = l.Name,
                        LocationId = l.Id,
                        VictimClass = vc.Name,
                        VictimName = v.Name,
                        VictimId = v.Id,
                        VictimClassId = k.VictimClass1Id
                    }).Skip((page - 1) * DefaultPageSize).Take(DefaultPageSize);
        }
    }
}
