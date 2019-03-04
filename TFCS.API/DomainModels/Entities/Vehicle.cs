using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCS.API.DomainModels.Entities
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]        
        public string Vin { get; set; }
        public int Year { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int CompanyId { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]        
        public string CustomerName { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]        
        public string CustomerEmail { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]        
        public string CustHomePhone { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]        
        public string CustCellPhone { get; set; }

        // public virtual Company Company { get; set; }
        // public virtual VehicleMake Make { get; set; }
        // public virtual VehicleModel Model { get; set; }
 
    }
}
