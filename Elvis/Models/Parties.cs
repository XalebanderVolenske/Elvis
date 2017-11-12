namespace Elvis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Parties
    {
        [Key]
        [StringLength(255)]
        public string Code { get; set; }

        [Column("Full Name")]
        [Required]
        [StringLength(255)]
        public string Full_Name { get; set; }

        [StringLength(255)]
        public string Color { get; set; }

        public virtual Election_Parties Election_Parties { get; set; }
    }
}
