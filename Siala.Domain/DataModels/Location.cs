using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siala.Domain.DataModels
{
    public class Location
    {
        #region Properties
        [Key]
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public Int32 FactionId { get; set; }
        #endregion Properties

        #region Related Properties

        //[ForeignKey("FactionId")]
        //public virtual Faction LocationFaction { get; set; }

        #endregion Related Properties
    }
}