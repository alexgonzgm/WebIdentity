using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebIdentity.Models
{
    public class Department
    {
         public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Office { get; set; }
        public ICollection<Club> Clubes { get; set; }
    }
}
