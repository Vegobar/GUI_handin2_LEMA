using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI_Try2222.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser(): base() { }

        public string Name { get; set; }
        public string Position { get; set; }

    }
}
