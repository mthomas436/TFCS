using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFCS.API.DomainModels.Dtos
{
    public class UserForEditDto
    {
        public int UserId { get; set; }

        [StringLength(50)]
        public string Firstname { get; set; }


        [StringLength(50)]
        public string Lastname { get; set; }


        [StringLength(50)]
        public string Email { get; set; }

    }
}
