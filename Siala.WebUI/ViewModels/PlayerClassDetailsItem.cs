using System;

namespace Siala.WebUI.ViewModels
{
    public class PlayerClassDetailsItem
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Int32 TotalKills { get; set; }
        public Int32 TotalDeaths { get; set; }
    }
}