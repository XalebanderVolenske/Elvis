namespace Elvis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Electorial_Register
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string ElectionCode { get; set; }

        [Key]
        [Column("Community Index", Order = 1)]
        [StringLength(255)]
        public string Community_Index { get; set; }

        [Column("Eligible Voters")]
        public long? Eligible_Voters { get; set; }

        public virtual Communities Communities { get; set; }

        public virtual Elections Elections { get; set; }
    }
}
