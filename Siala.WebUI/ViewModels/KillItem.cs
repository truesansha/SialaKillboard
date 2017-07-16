using System;

namespace Siala.WebUI.ViewModels
{
    public class KillItem
    {
        public Int32 KillId { get; set; }
        public DateTime KillTime { get; set; }
        public String VictimName { get; set; }
        public String VictimClass { get; set; }
        public String KillerName { get; set; }
        public String LocationName { get; set; }
        public String VictimFaction { get; set; }
        public Byte VictimFactionId { get; set; }
    }
}