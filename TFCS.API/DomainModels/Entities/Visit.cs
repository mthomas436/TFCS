using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TFCS.API.DomainModels.Entities
{
    public class visit
    {
        [Key]
        public int VisitId { get; set; }
        public DateTime VisitDate { get; set; }

        [Column(TypeName = "VARCHAR(25)")]
        [StringLength(25)]            
        public string Salesman { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(15)]            
        public string RO { get; set; }
        
        public int SA { get; set; }
        public int Tech { get; set; }
        public int Category { get; set; }
        public decimal Mileage { get; set; }
        public int vehicle_id { get; set; }
        public bool NoEmail { get; set; }
    }
}