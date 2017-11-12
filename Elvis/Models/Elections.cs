namespace Elvis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Elections
    {
        public Elections()
        {
            Election_Parties = new HashSet<Election_Parties>();
            Electorial_Register = new HashSet<Electorial_Register>();
        }

        [Key]
        [StringLength(255)]
        public string Code { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Column("Due Date", TypeName = "date")]
        public DateTime Due_Date { get; set; }

        public virtual ICollection<Election_Parties> Election_Parties { get; set; }

        public virtual ICollection<Electorial_Register> Electorial_Register { get; set; }
    }
}
