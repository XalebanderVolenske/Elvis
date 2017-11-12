namespace Elvis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Constituencies
    {
        public Constituencies()
        {
            Districts = new HashSet<Districts>();
        }

        [Key]
        [StringLength(255)]
        public string Code { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        public double ProvinceCode { get; set; }

        [Column("Valid From", TypeName = "date")]
        public DateTime Valid_From { get; set; }

        [Column("Valid To", TypeName = "date")]
        public DateTime? Valid_To { get; set; }

        public virtual Provinces Provinces { get; set; }

        public virtual ICollection<Districts> Districts { get; set; }
    }
}
