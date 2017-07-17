using System;
using System.ComponentModel.DataAnnotations;

namespace Siala.Domain.DataModels
{
    public class Faction
    {
        #region Properties
        [Key]
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
        #endregion Properties
    }
}