using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TFCS.API.DomainModels.Entities
{
    public class User : IdentityUser<int>
    {
        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]        
        public string FirstName { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]        
        public string LastName { get; set; }
 

        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Lastactive { get; set; }

        public virtual Company Company { get; set; }
        public virtual CompanyEmployee CompanyEmployee { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public User()
        {
            this.Active = true;
            this.Created = DateTime.Now;
            this.Lastactive = DateTime.Now;
        }
 
    }
}
