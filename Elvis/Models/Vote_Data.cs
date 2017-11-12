namespace Elvis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vote_Data
    {
        [Column("Election Code")]
        [Required]
        [StringLength(255)]
        public string Election_Code { get; set; }

        [Key]
        [Column("Community Index")]
        [StringLength(255)]
        public string Community_Index { get; set; }

        [Column("Party Code")]
        [Required]
        [StringLength(255)]
        public string Party_Code { get; set; }

        public double? Votes { get; set; }

        public virtual Communities Communities { get; set; }

        public virtual Election_Parties Election_Parties { get; set; }
    }
}
