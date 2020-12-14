using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebIdentity.Models
{
    public class Registration
    {
        public int RegistrationId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ClubId { get; set; }
        public Club Club { get; set; }
    
    }
}
