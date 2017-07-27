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
            return (from k in Repository.Kills
                    where k.LocationId == locationId
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
