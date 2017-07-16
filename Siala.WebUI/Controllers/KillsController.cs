using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Siala.WebUI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Siala.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class KillsController : BaseController
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<KillItem> Get()
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

        // GET api/values/5
        [HttpGet("{id}")]
        public String Get(int id)
        {
            return "value";
        }
    }
}
