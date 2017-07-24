using System;
using Microsoft.AspNetCore.Mvc;
using Siala.WebUI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Siala.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public KillItem Get(int id)
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
