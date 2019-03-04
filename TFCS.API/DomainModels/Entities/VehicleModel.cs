using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCS.API.DomainModels.Entities
{
    public class VehicleModel
    {
        public VehicleModel()
        {
            //Vehicles = new HashSet<Vehicle>();
        }

        
        public VehicleModel(int modelId, string description)
        {
            this.ModelId = modelId;
            this.Description = description;

        }

        [Key]
        public int ModelId { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string Description { get; set; }

        //public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
