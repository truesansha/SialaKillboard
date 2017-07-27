using System;
using System.Collections.Generic;

namespace Siala.WebUI.ViewModels
{
    public class KillDetailsItem
    {
        public KillDetailsItem()
        {
            InvolvedPlayers = new List<PlayerDetailsItem>();
        }

        public Int32 KillId { get; set; }
        public DateTime KillTime { get; set; }
        public Int32 KillerId { get; set; }
        public String LocationName { get; set; }
        public Int32 LocationId { get; set; }
        public PlayerDetailsItem VictimDetails { get; set; }
        public List<PlayerDetailsItem> InvolvedPlayers { get; set; }
    }
}
