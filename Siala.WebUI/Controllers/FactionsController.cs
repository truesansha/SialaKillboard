using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Clauses;
using Siala.Domain.Repository;
using Siala.WebUI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Siala.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class FactionsController : BaseController
    {
        // GET api/factions/5
        public FactionsController(IKillboardRepository repository) : base(repository)
        {
        }

        [HttpGet("{id}")]
        public FactionDetailsItem Get(Int32 id)
        {
            FactionDetailsItem factionDetails = Repository.Factions.Select(f => new FactionDetailsItem
            {
                Id = f.Id,
                Name = f.Name,
                Description = f.Description
            }).FirstOrDefault(f => f.Id == id);

            if (factionDetails != null)
            {
                factionDetails.TotalDeaths = Repository.Kills.Count(f => f.VictimFactionId == id);
                factionDetails.TotalKills = (from k in Repository.Kills
                                             join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
                                             where ip.AttackerFactionId == id && ip.AttackerId == k.FinalBlowPlayerId
                                             select ip).Count();
            }

            return factionDetails;
        }

        [HttpGet("FactionKills/{factionId}/{page}")]
        public IEnumerable<KillItem> FactionKills(Int32 factionId, Int32 page)
        {
            return (from k in Repository.Kills
                    join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
                    where k.FinalBlowPlayerId == ip.AttackerId && ip.AttackerFactionId == factionId
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

        [HttpGet("FactionDeaths/{factionId}/{page}")]
        public IEnumerable<KillItem> FactionDeaths(Int32 factionId, Int32 page)
        {
            return (from k in Repository.Kills
                    where k.VictimFactionId == factionId
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
