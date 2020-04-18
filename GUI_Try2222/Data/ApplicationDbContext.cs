using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GUI_Try2222.Data;
using GUI_Try2222.Models;

namespace GUI_Try2222.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GUI_Try2222.Data.Booking> Booking { get; set; }
        public DbSet<GUI_Try2222.Data.ExpectedArrival> ExpectedArrival { get; set; }

    }
}
