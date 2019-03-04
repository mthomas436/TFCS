using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCS.API.DomainModels.Entities
{
    public class Company
    {
        public Company()
        {
            Surveys = new HashSet<Survey>();
            // Vehicles = new HashSet<Vehicle>();
            // Employees = new HashSet<CompanyEmployee>();
        }

        [Key]
        public int CompanyId { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]        
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR(500)")]
        [StringLength(500)]        
        public string Description { get; set; }

        [Column(TypeName = "VARCHAR(500)")]
        [StringLength(500)]        
        public string LogoImagePath { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }

    }
}
