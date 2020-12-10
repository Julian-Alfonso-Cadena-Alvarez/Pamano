using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pamano.Web.Models
{
    public class CreateRolViewModel
    {   
        [Required]
        public string RolName { get; set; }
    }
}
