using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siala.Domain.DataModels
{
    public class InvolvedPlayer
    {
        #region Properties

        [Key]
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 KillId { get; set; }
        [Required]
        public Int32 AttackerId { get; set; }
        [Required]
        public Int32 AttackerClass1Id { get; set; }
        [Required]
        public Int32 AttackerClass1Level { get; set; }
        public Int32? AttackerClass2Id { get; set; }
        public Int32? AttackerClass2Level { get; set; }
        public Int32? AttackerClass3Id { get; set; }
        public Int32? AttackerClass3Level { get; set; }
        [Required]
        public Int32 AttackerFactionId { get; set; }
        [Required]
        public Int32 AttackerRaceId { get; set; }
        [Required]
        public Int32 DamageDone { get; set; }

        #endregion Properties

        #region Related Properties

        //[ForeignKey("KillId")]
        //public virtual Kill InvolvedKill { get; set; }

        //[ForeignKey("AttackerClass1Id")]
        //public virtual PlayerClass AttackerClass1 { get; set; }

        //[ForeignKey("AttackerClass2Id")]
        //public virtual PlayerClass AttackerClass2 { get; set; }

        //[ForeignKey("AttackerClass3Id")]
        //public virtual PlayerClass AttackerClass3 { get; set; }

        //[ForeignKey("AttackerFactionId")]
        //public virtual Faction AttackerFaction { get; set; }

        //[ForeignKey("AttackerRaceId")]
        //public virtual PlayerRace AttackerRace { get; set; }

        #endregion Related Properties
    }
}