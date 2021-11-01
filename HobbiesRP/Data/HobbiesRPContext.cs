using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HobbiesRP.Models;

namespace HobbiesRP.Data
{
    public class HobbiesRPContext : DbContext
    {
        public HobbiesRPContext (DbContextOptions<HobbiesRPContext> options)
            : base(options)
        {
        }

        public DbSet<HobbiesRP.Models.Hobby> Hobby { get; set; }
    }
}
