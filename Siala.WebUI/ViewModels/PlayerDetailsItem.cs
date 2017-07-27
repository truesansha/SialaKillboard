using System;

namespace Siala.WebUI.ViewModels
{
    public class PlayerDetailsItem
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Int32 Class1Id { get; set; }
        public Int32 Class2Id { get; set; }
        public Int32 Class3Id { get; set; }
        public String Class1 { get; set; }
        public String Class2 { get; set; }
        public String Class3 { get; set; }
        public Int32 Class1Level { get; set; }
        public Int32 Class2Level { get; set; }
        public Int32 Class3Level { get; set; }
        public Int32 RaceId { get; set; }
        public String Race { get; set; }
        public Int32 FactionId { get; set; }
        public String Faction { get; set; }
        public Int32 Damage { get; set; }
        public Int32 TotalKills { get; set; }
        public Int32 TotalDeaths { get; set; }
    }
}
