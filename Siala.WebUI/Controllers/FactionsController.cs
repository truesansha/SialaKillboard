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
            IEnumerable<KillItem> killList = (from k in Repository.Kills
                                              join v in Repository.Players on k.VictimId equals v.Id
                                              join vc in Repository.PlayerClasses on k.VictimClass1Id equals vc.Id
                                              join vf in Repository.Factions on k.VictimFactionId equals vf.Id
                                              join kl in Repository.Players on k.FinalBlowPlayerId equals kl.Id
                                              join l in Repository.Locations on k.LocationId equals l.Id
                                              join lf in Repository.Factions on l.FactionId equals lf.Id
                                              join fb in Repository.InvolvedPlayes on k.Id equals fb.KillId
                                              join fbc in Repository.PlayerClasses on fb.AttackerClass1Id equals fbc.Id
                                              join fbf in Repository.Factions on fb.AttackerFactionId equals fbf.Id
                                              where fb.AttackerId == k.FinalBlowPlayerId && fb.AttackerFactionId == factionId
                                              orderby k.KillTime descending
                                              select new KillItem
                                              {
                                                  KillTime = k.KillTime,
                                                  KillId = k.Id,
                                                  VictimFactionId = (byte)vf.Id,
                                                  VictimFaction = vf.Name,
                                                  VictimClassId = k.VictimClass1Id,
                                                  VictimId = v.Id,
                                                  VictimClass = vc.Name,
                                                  VictimName = v.Name,
                                                  KillerFactionId = fb.AttackerFactionId,
                                                  KillerFaction = fbf.Name,
                                                  KillerClassId = fb.AttackerClass1Id,
                                                  KillerClass = fbc.Name,
                                                  KillerId = kl.Id,
                                                  KillerName = kl.Name,
                                                  LocationName = l.Name,
                                                  LocationId = l.Id,
                                                  LocationFactionId = l.FactionId,
                                                  LocationFaction = lf.Name
                                              }).Skip((page - 1) * DefaultPageSize).Take(DefaultPageSize);

            return killList.ToList();
        }

        [HttpGet("FactionDeaths/{factionId}/{page}")]
        public IEnumerable<KillItem> FactionDeaths(Int32 factionId, Int32 page)
        {
            IEnumerable<KillItem> killList = (from k in Repository.Kills
                                              join v in Repository.Players on k.VictimId equals v.Id
                                              join vc in Repository.PlayerClasses on k.VictimClass1Id equals vc.Id
                                              join vf in Repository.Factions on k.VictimFactionId equals vf.Id
                                              join kl in Repository.Players on k.FinalBlowPlayerId equals kl.Id
                                              join l in Repository.Locations on k.LocationId equals l.Id
                                              join lf in Repository.Factions on l.FactionId equals lf.Id
                                              join fb in Repository.InvolvedPlayes on k.Id equals fb.KillId
                                              join fbc in Repository.PlayerClasses on fb.AttackerClass1Id equals fbc.Id
                                              join fbf in Repository.Factions on fb.AttackerFactionId equals fbf.Id
                                              where fb.AttackerId == k.FinalBlowPlayerId && k.VictimFactionId == factionId
                                              orderby k.KillTime descending
                                              select new KillItem
                                              {
                                                  KillTime = k.KillTime,
                                                  KillId = k.Id,
                                                  VictimFactionId = (byte)vf.Id,
                                                  VictimFaction = vf.Name,
                                                  VictimClassId = k.VictimClass1Id,
                                                  VictimId = v.Id,
                                                  VictimClass = vc.Name,
                                                  VictimName = v.Name,
                                                  KillerFactionId = fb.AttackerFactionId,
                                                  KillerFaction = fbf.Name,
                                                  KillerClassId = fb.AttackerClass1Id,
                                                  KillerClass = fbc.Name,
                                                  KillerId = kl.Id,
                                                  KillerName = kl.Name,
                                                  LocationName = l.Name,
                                                  LocationId = l.Id,
                                                  LocationFactionId = l.FactionId,
                                                  LocationFaction = lf.Name
                                              }).Skip((page - 1) * DefaultPageSize).Take(DefaultPageSize);

            return killList.ToList();
        }
    }
}
