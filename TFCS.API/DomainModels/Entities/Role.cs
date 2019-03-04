using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;


namespace TFCS.API.DomainModels.Entities
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
