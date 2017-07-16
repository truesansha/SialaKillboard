using System;
using Microsoft.AspNetCore.Mvc;
using Siala.WebUI.ViewModels;

namespace Siala.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class SummaryController : BaseController
    {
        // GET api/values
        [HttpGet]
        public SummaryItem Get()
        {
            //throw new NullReferenceException();
            return new SummaryItem
            {
                ArcaneArcherKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                ArcaneArcherDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                AssassinKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                AssassinDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                BarbarianKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                BarbarianDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                BardKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                BardDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                BlackguardKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                BlackguardDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                CotKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                CotDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                ClericKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                ClericDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                DruidKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                DruidDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                DdKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                DdDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                FigherKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                FighterDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                MonkKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                MonkDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                PaladinKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                PaladinDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                PmKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                PmDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                RangerKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                RangerDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                RddKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                RddDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                RogueKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                RogueDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                ShadowdancerKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                ShadowdancerDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                ShifterKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                ShifterDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                SorcererKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                SorcererDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                WmKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                WmDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                WizardKills = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200),
                WizardDeaths = new Random(Guid.NewGuid().GetHashCode()).Next(0, 200)
            };
        }
    }
}
