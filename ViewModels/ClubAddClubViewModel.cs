using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebIdentity.Models;

namespace WebIdentity.ViewModels
{
    public class ClubAddClubViewModel
    {
        public Club Club { get; set; }
        public Department Department { get; set; }
        public SelectList DepartmentList { get; set; }
    }
}
