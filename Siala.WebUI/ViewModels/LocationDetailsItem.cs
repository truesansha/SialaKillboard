using System;

namespace Siala.WebUI.ViewModels
{
    public class LocationDetailsItem
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Int32 FactionId { get; set; }
        public String FactionName { get; set; }
        public Int32 TotalKills { get; set; }
    }
}