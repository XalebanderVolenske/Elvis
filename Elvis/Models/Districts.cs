namespace Elvis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Districts
    {
        public Districts()
        {
            Communities = new HashSet<Communities>();
        }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Key]
        public double Code { get; set; }

        [Required]
        [StringLength(255)]
        public string regional_constituency { get; set; }

        [Column("Valid From", TypeName = "date")]
        public DateTime Valid_From { get; set; }

        [Column("Valid To", TypeName = "date")]
        public DateTime? Valid_To { get; set; }

        public virtual ICollection<Communities> Communities { get; set; }

        public virtual Constituencies Constituencies { get; set; }
    }
}
