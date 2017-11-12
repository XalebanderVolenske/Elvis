namespace Elvis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Districts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Communities> Communities { get; set; }

        public virtual Constituencies Constituencies { get; set; }
    }
}
