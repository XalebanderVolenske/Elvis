namespace Elvis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Election_Parties
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Election_Parties()
        {
            Vote_Data = new HashSet<Vote_Data>();
        }

        [Column("Election Code")]
        [Required]
        [StringLength(255)]
        public string Election_Code { get; set; }

        [Key]
        [Column("Party Code")]
        [StringLength(255)]
        public string Party_Code { get; set; }

        public virtual Elections Elections { get; set; }

        public virtual Parties Parties { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vote_Data> Vote_Data { get; set; }
    }
}
