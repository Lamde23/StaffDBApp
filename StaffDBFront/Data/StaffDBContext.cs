using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StaffDBFront.Models;

namespace StaffDBFront.Data
{
    public class StaffDBContext : DbContext
    {
        public StaffDBContext (DbContextOptions<StaffDBContext> options)
            : base(options)
        {
        }

        public DbSet<StaffDBFront.Models.Staff> Staff { get; set; } = default!;
    }
}
