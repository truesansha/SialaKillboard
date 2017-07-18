using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siala.Domain.DataModels
{
    public class Kill
    {
        #region Properties

        [Key]
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public DateTime KillTime { get; set; }
        [Required]
        public Int32 VictimId { get; set; }
        [Required]
        public Int32 VictimClass1Id { get; set; }
        [Required]
        public Int32 VictimClass1Level { get; set; }
        public Int32? VictimClass2Id { get; set; }
        public Int32? VictimClass2Level { get; set; }
        public Int32? VictimClass3Id { get; set; }
        public Int32? VictimClass3Level { get; set; }
        [Required]
        public Int32 VictimFactionId { get; set; }
        [Required]
        public Int32 VictimRaceId { get; set; }
        [Required]
        public Int32 LocationId { get; set; }
        [Required]
        public Int32 DamageTaken { get; set; }
        [Required]
        public Int32 FinalBlowPlayerId { get; set; }

        #endregion Properties

        #region Related Properties

        //[ForeignKey("VictimId")]
        //public virtual Player VictimPlayer { get; set; }

        //[ForeignKey("VictimClass1Id")]
        //public virtual PlayerClass VictimClass1 { get; set; }

        //[ForeignKey("VictimClass2Id")]
        //public virtual PlayerClass VictimClass2 { get; set; }

        //[ForeignKey("VictimClass3Id")]
        //public virtual PlayerClass VictimClass3 { get; set; }

        //[ForeignKey("VictimFactionId")]
        //public virtual Faction VictimFaction { get; set; }

        //[ForeignKey("VictimRaceId")]
        //public virtual PlayerRace VictimRace { get; set; }

        //[ForeignKey("LocationId")]
        //public virtual Location KillLocation { get; set; }

        #endregion Related Properties
    }
}