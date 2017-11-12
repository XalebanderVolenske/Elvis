namespace Elvis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Communities
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Communities()
        {
            Electorial_Register = new HashSet<Electorial_Register>();
        }

        [Key]
        [Column("Community Index")]
        [StringLength(255)]
        public string Community_Index { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Column("Post Code")]
        public double Post_Code { get; set; }

        [Column("District Code")]
        public double District_Code { get; set; }

        [Column("Valid From", TypeName = "date")]
        public DateTime Valid_From { get; set; }

        [Column("Valid To", TypeName = "date")]
        public DateTime? Valid_To { get; set; }

        public virtual Districts Districts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Electorial_Register> Electorial_Register { get; set; }

        public virtual Vote_Data Vote_Data { get; set; }
    }
}
