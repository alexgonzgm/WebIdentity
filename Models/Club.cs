using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebIdentity.Models
{
    public class Club
    {
        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public int NumberOfStudents { get; set; }
        public Department Department { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}
