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
        private readonly IKillboardRepository _repository;
        private Int32 _defaultPageSize = 30;

        public KillsController(IKillboardRepository repository)
        {
            _repository = repository;
        }

        // GET: api/list
        [HttpGet("List")]
        public IEnumerable<KillItem>List()
        {
            return List(1);
        }

        [HttpGet("List/{page}")]
        public IEnumerable<KillItem> List(Int32 page)
        {
            IEnumerable<KillItem> killList = from k in _repository.Kills
                join v in _repository.Players on k.VictimId equals v.Id
                join vc in _repository.PlayerClasses on k.VictimClass1Id equals vc.Id
                join vf in _repository.Factions on k.VictimFactionId equals vf.Id
                join kl in _repository.Players on k.FinalBlowPlayerId equals kl.Id
                join l in _repository.Locations on k.LocationId equals l.Id
                orderby k.KillTime descending
                select new KillItem
                {
                    KillTime = k.KillTime,
                    VictimFactionId = (byte) vf.Id,
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
                };

            return killList.Skip((page-1) * _defaultPageSize).Take(_defaultPageSize).ToList();
        }

        // GET api/kills/5
        [HttpGet("{id}")]
        public KillItem Get(Int32 id)
        {
            return new KillItem
            {
                KillId = 1,
                KillTime = DateTime.Now.AddDays(-4),
                VictimName = "Бульбазавр",
                VictimClass = "Bard",
                KillerName = "Ивизавр",
                LocationName = "Авендум",
                VictimFaction = "Рачье Герцогство",
                VictimFactionId = 1
            };
        }
    }
}
