namespace Elvis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Provinces
    {
        public Provinces()
        {
            Constituencies = new HashSet<Constituencies>();
        }

        [Key]
        public double Code { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public virtual ICollection<Constituencies> Constituencies { get; set; }
    }
}
