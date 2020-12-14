using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebIdentity.Models
{
    public class UserRole : List<IdentityUser>
    {
        public List<string> role { get; set; }
    }
}
