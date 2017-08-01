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
    public class LocationsController : BaseController
    {
        // GET api/locations/5
        public LocationsController(IKillboardRepository repository) : base(repository)
        {
        }

        [HttpGet("{id}")]
        public LocationDetailsItem Get(Int32 id)
        {
            LocationDetailsItem locationDetails = (from l in Repository.Locations
                                                   where l.Id == id
                                                   join f in Repository.Factions on l.FactionId equals f.Id
                                                   select new LocationDetailsItem
                                                   {
                                                       Id = l.Id,
                                                       Name = l.Name,
                                                       FactionId = f.Id,
                                                       FactionName = f.Name
                                                   }).FirstOrDefault();

            if (locationDetails != null)
            {
                locationDetails.TotalKills = Repository.Kills.Count(k => k.LocationId == id);
            }

            return locationDetails;
        }

        [HttpGet("LocationKills/{locationId}/{page}")]
        public IEnumerable<KillItem> LocationKills(Int32 locationId, Int32 page)
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
                                              where fb.AttackerId == k.FinalBlowPlayerId && k.LocationId == locationId
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
