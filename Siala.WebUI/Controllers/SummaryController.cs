using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Siala.WebUI.ViewModels;

namespace Siala.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class SummaryController : Controller
    {
        // GET api/values
        [HttpGet("GetSummary")]
        public JsonResult GetSummary()
        {
            return new JsonResult(new SummaryItem
            {
                arcaneArcherKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                arcaneArcherDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                assassinKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                assassinDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                barbarianKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                barbarianDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                bardKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                bardDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                blackguardKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                blackguardDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                cotKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                cotDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                clericKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                clericDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                druidKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                druidDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                ddKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                ddDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                figherKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                fighterDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                monkKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                monkDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                paladinKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                paladinDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                pmKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                pmDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                rangerKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                rangerDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                rddKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                rddDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                rogueKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                rogueDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                shadowdancerKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                shadowdancerDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                shifterKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                shifterDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                sorcererKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                sorcererDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                wmKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                wmDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                wizardKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                wizardDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200)
            }, DefaultJsonSettings);
        }

        private JsonSerializerSettings DefaultJsonSettings => new JsonSerializerSettings
        {
            Formatting = Formatting.Indented
        };
    }
}
