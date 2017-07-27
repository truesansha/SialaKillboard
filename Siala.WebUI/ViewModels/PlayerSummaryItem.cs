using System.Collections.Generic;

namespace Siala.WebUI.ViewModels
{
    public class PlayerSummaryItem
    {
        public PlayerSummaryItem()
        {
            KillList = new List<KillItem>();
            DeathList = new List<KillItem>();
        }

        public PlayerDetailsItem Player { get; set; }
        public List<KillItem> KillList { get; set; }
        public List<KillItem> DeathList { get; set; }
    }
}
