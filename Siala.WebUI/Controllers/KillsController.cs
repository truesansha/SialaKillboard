using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
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
        [HttpGet("List/{page}")]
        public IEnumerable<KillItem> List(Int32 page = 1)
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
                    LocationName = l.Name,
                    VictimClass = vc.Name,
                    VictimName = v.Name
                };

            return killList.Skip((page-1) * _defaultPageSize).Take(_defaultPageSize).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public String Get(int id)
        {
            return "value";
        }

        private List<KillItem> GetSampleKills()
        {
            return new List<KillItem>
            {
                new KillItem
                {
                    KillId = 1,
                    KillTime = DateTime.Now.AddDays(-4),
                    VictimName = "Бульбазавр",
                    VictimClass = "Bard",
                    KillerName = "Ивизавр",
                    LocationName = "Авендум",
                    VictimFaction = "Рачье Герцогство",
                    VictimFactionId = 1
                },
                new KillItem
                {
                    KillId = 2,
                    KillTime = DateTime.Now.AddDays(-3),
                    VictimName = "Венузавр",
                    VictimClass = "Druid",
                    KillerName = "Пикачу",
                    LocationName = "Авендум",
                    VictimFaction = "Рачье Герцогство",
                    VictimFactionId = 1
                },
                new KillItem
                {
                    KillId = 3,
                    KillTime = DateTime.Now.AddDays(-2),
                    VictimName = "Слоупок",
                    VictimClass = "Sorcerer",
                    KillerName = "Пикачу",
                    LocationName = "Авендум",
                    VictimFaction = "Рачье Герцогство",
                    VictimFactionId = 1
                },
                new KillItem
                {
                    KillId = 4,
                    KillTime = DateTime.Now.AddDays(-1),
                    VictimName = "Пикачу",
                    VictimClass = "Sorcerer",
                    KillerName = "Слоупок",
                    LocationName = "Инсанна: Зал Советов",
                    VictimFaction = "Валиостр",
                    VictimFactionId = 0
                },
                new KillItem
                {
                    KillId = 5,
                    KillTime = DateTime.Now.AddDays(0),
                    VictimName = "Сквиртл",
                    VictimClass = "Paladin",
                    KillerName = "Слоупок",
                    LocationName = "Инсанна",
                    VictimFaction = "Валиостр",
                    VictimFactionId = 0
                }
            };
        }
    }
}
