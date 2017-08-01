using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Siala.Domain.Repository;
using Siala.WebUI.ViewModels;

namespace Siala.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class SummaryController : BaseController
    {
        public SummaryController(IKillboardRepository repository) : base(repository)
        {
        }

        [HttpGet]
        public IEnumerable<SummaryItem> Get()
        {
            //throw new NullReferenceException();
            IEnumerable<SummaryItem> summaryItems = from c in Repository.PlayerClasses
                select new SummaryItem
                {
                    ClassName = c.Name,
                    ClassDeaths = Repository.Kills.Count(k => k.VictimClass1Id == c.Id),
                    ClassKills = (from k in Repository.Kills
                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
                                 where ip.AttackerClass1Id == c.Id && ip.AttackerId == k.FinalBlowPlayerId
                                 select ip).Count()
                };
            return summaryItems.Where(s => s.ClassName != "Harper Scout").OrderBy(c => c.ClassName);
            //return new SummaryItem
            //{
            //    ArcaneArcherKills = (from k in Repository.Kills
            //                         join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                         where ip.AttackerClass1Id == 11 && ip.AttackerId == k.FinalBlowPlayerId
            //                         select ip).Count(),
            //    ArcaneArcherDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 11),
            //    AssassinKills = (from k in Repository.Kills
            //                     join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                     where ip.AttackerClass1Id == 13 && ip.AttackerId == k.FinalBlowPlayerId
            //                     select ip).Count(),
            //    AssassinDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 13),
            //    BarbarianKills = (from k in Repository.Kills
            //                      join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                      where ip.AttackerClass1Id == 12 && ip.AttackerId == k.FinalBlowPlayerId
            //                      select ip).Count(),
            //    BarbarianDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 12),
            //    BardKills = (from k in Repository.Kills
            //                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                 where ip.AttackerClass1Id == 21 && ip.AttackerId == k.FinalBlowPlayerId
            //                 select ip).Count(),
            //    BardDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 21),
            //    BlackguardKills = (from k in Repository.Kills
            //                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                                 where ip.AttackerClass1Id == 10 && ip.AttackerId == k.FinalBlowPlayerId
            //                                 select ip).Count(),
            //    BlackguardDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 10),
            //    CotKills = (from k in Repository.Kills
            //                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                                 where ip.AttackerClass1Id == 9 && ip.AttackerId == k.FinalBlowPlayerId
            //                                 select ip).Count(),
            //    CotDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 9),
            //    ClericKills = (from k in Repository.Kills
            //                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                                 where ip.AttackerClass1Id == 8 && ip.AttackerId == k.FinalBlowPlayerId
            //                                 select ip).Count(),
            //    ClericDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 8),
            //    DruidKills = (from k in Repository.Kills
            //                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                                 where ip.AttackerClass1Id == 7 && ip.AttackerId == k.FinalBlowPlayerId
            //                                 select ip).Count(),
            //    DruidDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 7),
            //    DdKills = (from k in Repository.Kills
            //                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                                 where ip.AttackerClass1Id == 6 && ip.AttackerId == k.FinalBlowPlayerId
            //                                 select ip).Count(),
            //    DdDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 6),
            //    FigherKills = (from k in Repository.Kills
            //                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                                 where ip.AttackerClass1Id == 5 && ip.AttackerId == k.FinalBlowPlayerId
            //                                 select ip).Count(),
            //    FighterDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 5),
            //    MonkKills = (from k in Repository.Kills
            //                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                                 where ip.AttackerClass1Id == 4 && ip.AttackerId == k.FinalBlowPlayerId
            //                                 select ip).Count(),
            //    MonkDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 4),
            //    PaladinKills = (from k in Repository.Kills
            //                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                                 where ip.AttackerClass1Id == 3 && ip.AttackerId == k.FinalBlowPlayerId
            //                                 select ip).Count(),
            //    PaladinDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 3),
            //    PmKills = (from k in Repository.Kills
            //                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                                 where ip.AttackerClass1Id == 2 && ip.AttackerId == k.FinalBlowPlayerId
            //                                 select ip).Count(),
            //    PmDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 2),
            //    RangerKills = (from k in Repository.Kills
            //                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                                 where ip.AttackerClass1Id == 14 && ip.AttackerId == k.FinalBlowPlayerId
            //                                 select ip).Count(),
            //    RangerDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 14),
            //    RddKills = (from k in Repository.Kills
            //                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                                 where ip.AttackerClass1Id == 22 && ip.AttackerId == k.FinalBlowPlayerId
            //                                 select ip).Count(),
            //    RddDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 22),
            //    RogueKills = (from k in Repository.Kills
            //                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                                 where ip.AttackerClass1Id == 1 && ip.AttackerId == k.FinalBlowPlayerId
            //                                 select ip).Count(),
            //    RogueDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 1),
            //    ShadowdancerKills = (from k in Repository.Kills
            //                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                                 where ip.AttackerClass1Id == 15 && ip.AttackerId == k.FinalBlowPlayerId
            //                                 select ip).Count(),
            //    ShadowdancerDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 15),
            //    ShifterKills = (from k in Repository.Kills
            //                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                                 where ip.AttackerClass1Id == 16 && ip.AttackerId == k.FinalBlowPlayerId
            //                                 select ip).Count(),
            //    ShifterDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 16),
            //    SorcererKills = (from k in Repository.Kills
            //                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                                 where ip.AttackerClass1Id == 17 && ip.AttackerId == k.FinalBlowPlayerId
            //                                 select ip).Count(),
            //    SorcererDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 17),
            //    WmKills = (from k in Repository.Kills
            //                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                                 where ip.AttackerClass1Id == 18 && ip.AttackerId == k.FinalBlowPlayerId
            //                                 select ip).Count(),
            //    WmDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 18),
            //    WizardKills = (from k in Repository.Kills
            //                                 join ip in Repository.InvolvedPlayes on k.Id equals ip.KillId
            //                                 where ip.AttackerClass1Id == 19 && ip.AttackerId == k.FinalBlowPlayerId
            //                                 select ip).Count(),
            //    WizardDeaths = Repository.Kills.Count(f => f.VictimClass1Id == 19)
            //};
        }
    }
}
