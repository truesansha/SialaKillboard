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
    public class KillsController : BaseController
    {
        // GET: api/list
        public KillsController(IKillboardRepository repository) : base(repository)
        {
        }

        [HttpGet("List")]
        public IEnumerable<KillItem> List()
        {
            return List(1);
        }

        [HttpGet("List/{page}")]
        public IEnumerable<KillItem> List(Int32 page)
        {
            IEnumerable<KillItem> killList = (from k in Repository.Kills
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

            return killList.ToList();
        }

        // GET api/kills/5
        [HttpGet("{id}")]
        public KillDetailsItem Get(Int32 id)
        {

            KillDetailsItem killDetails = (from k in Repository.Kills
                                           where k.Id == id
                                           join v in Repository.Players on k.VictimId equals v.Id
                                           join vr in Repository.Races on v.RaceId equals vr.Id
                                           join vc1 in Repository.PlayerClasses on k.VictimClass1Id equals vc1.Id
                                           join vc2 in Repository.PlayerClasses on k.VictimClass2Level ?? 0 equals vc2.Id into vc2L
                                           from vc2 in vc2L.DefaultIfEmpty()
                                           join vc3 in Repository.PlayerClasses on k.VictimClass3Level ?? 0 equals vc3.Id into vc3L
                                           from vc3 in vc2L.DefaultIfEmpty()
                                           join vf in Repository.Factions on k.VictimFactionId equals vf.Id
                                           join kl in Repository.Players on k.FinalBlowPlayerId equals kl.Id
                                           join l in Repository.Locations on k.LocationId equals l.Id
                                           orderby k.KillTime descending
                                           select new KillDetailsItem
                                           {
                                               KillId = k.Id,
                                               KillTime = k.KillTime,
                                               KillerId = kl.Id,
                                               LocationId = l.Id,
                                               LocationName = l.Name,
                                               VictimDetails = new PlayerDetailsItem
                                               {
                                                   Id = v.Id,
                                                   Name = v.Name,
                                                   RaceId = v.RaceId,
                                                   Race = vr.Name,
                                                   Class1Id = k.VictimClass1Id,
                                                   Class2Id = k.VictimClass2Id ?? 0,
                                                   Class3Id = k.VictimClass3Id ?? 0,
                                                   Class1 = vc1.Name,
                                                   Class2 = vc2?.Name,
                                                   Class3 = vc3?.Name,
                                                   Class1Level = k.VictimClass1Level,
                                                   Class2Level = k.VictimClass2Level ?? 0,
                                                   Class3Level = k.VictimClass3Level ?? 0,
                                                   FactionId = k.VictimFactionId,
                                                   Faction = vf.Name,
                                                   Damage = k.DamageTaken
                                               }
                                           }).FirstOrDefault();

            killDetails?.InvolvedPlayers.AddRange(
                from ip in Repository.InvolvedPlayes
                join k in Repository.Kills on ip.KillId equals k.Id
                where k.Id == id
                join a in Repository.Players on ip.AttackerId equals a.Id
                join ar in Repository.Races on a.RaceId equals ar.Id
                join ac1 in Repository.PlayerClasses on ip.AttackerClass1Id equals ac1.Id
                join ac2 in Repository.PlayerClasses on ip.AttackerClass2Id ?? 0 equals ac2.Id into ac2L
                from ac2 in ac2L.DefaultIfEmpty()
                join ac3 in Repository.PlayerClasses on ip.AttackerClass3Id ?? 0 equals ac3.Id into ac3L
                from ac3 in ac2L.DefaultIfEmpty()
                join af in Repository.Factions on ip.AttackerFactionId equals af.Id
                select new PlayerDetailsItem
                {
                    Id = a.Id,
                    Name = a.Name,
                    RaceId = a.RaceId,
                    Race = ar.Name,
                    Class1Id = ip.AttackerClass1Id,
                    Class2Id = ip.AttackerClass2Id ?? 0,
                    Class3Id = ip.AttackerClass3Id ?? 0,
                    Class1 = ac1.Name,
                    Class2 = ac2?.Name,
                    Class3 = ac3?.Name,
                    Class1Level = ip.AttackerClass1Level,
                    Class2Level = ip.AttackerClass2Level ?? 0,
                    Class3Level = ip.AttackerClass3Level ?? 0,
                    FactionId = ip.AttackerFactionId,
                    Faction = af.Name,
                    Damage = ip.DamageDone,
                }
            );

            return killDetails;
        }
    }
}
