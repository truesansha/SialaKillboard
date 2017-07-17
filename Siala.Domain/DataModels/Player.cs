using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Siala.Domain.DataModels
{
    public class Player
    {
        #region Properties

        [Key]
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public Int32 Class1Id { get; set; }
        [Required]
        public Int32 Class1Level { get; set; }
        public Int32? Class2Id { get; set; }
        public Int32? Class2Level { get; set; }
        public Int32? Class3Id { get; set; }
        public Int32? Class3Level { get; set; }
        [Required]
        public Int32 FactionId { get; set; }
        [Required]
        public Int32 RaceId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }

        #endregion Properties

        #region Related Properties

        //[ForeignKey("Class1Id")]
        //public virtual PlayerClass Class1 { get; set; }

        //[ForeignKey("Class2Id")]
        //public virtual PlayerClass Class2 { get; set; }

        //[ForeignKey("Class3Id")]
        //public virtual PlayerClass Class3 { get; set; }

        //[ForeignKey("FactionId")]
        //public virtual Faction Faction { get; set; }

        //[ForeignKey("RaceId")]
        //public virtual PlayerRace Race { get; set; }

        #endregion Related Properties
    }
}
