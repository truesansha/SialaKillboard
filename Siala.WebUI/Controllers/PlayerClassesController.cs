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
    public class PlayerClassesController : BaseController
    {
        // GET api/playerclasses/5
        public PlayerClassesController(IKillboardRepository repository) : base(repository)
        {
        }

        [HttpGet("{id}")]
        public PlayerClassDetailsItem Get(Int32 id)
        {
            PlayerClassDetailsItem playerClassDetails =  Repository.PlayerClasses.Select(pc => new PlayerClassDetailsItem
            {
                Id = pc.Id,
                Name = pc.Name,
                Description = pc.Description
            }).FirstOrDefault(p => p.Id == id);

            if (playerClassDetails != null)
            {
                playerClassDetails.TotalDeaths = Repository.Kills.Count(f => f.VictimClass1Id == id);
                playerClassDetails.TotalKills = (from k in Repository.Kills
                                             join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
                                             where ip.AttackerClass1Id == id && ip.AttackerId == k.FinalBlowPlayerId
                                             select ip).Count();
            }

            return playerClassDetails;
        }

        [HttpGet("PlayerClassKills/{classId}/{page}")]
        public IEnumerable<KillItem> PlayerClassKills(Int32 classId, Int32 page)
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
                                              where fb.AttackerId == k.FinalBlowPlayerId && fb.AttackerClass1Id == classId
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

        [HttpGet("PlayerClassDeaths/{classId}/{page}")]
        public IEnumerable<KillItem> PlayerClassDeaths(Int32 classId, Int32 page)
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
                                              where fb.AttackerId == k.FinalBlowPlayerId && k.VictimClass1Id == classId
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
