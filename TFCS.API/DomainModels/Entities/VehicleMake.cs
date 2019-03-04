using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCS.API.DomainModels.Entities
{
    public class VehicleMake
    {
        public VehicleMake()
        {
           // Vehicles = new HashSet<Vehicle>();
        }
        [Key]
        public int MakeId { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]        
        public string Description { get; set; }

        //public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
