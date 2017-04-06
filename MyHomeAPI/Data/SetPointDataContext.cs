using Microsoft.EntityFrameworkCore;
using MyHomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Data
{
    public class SetPointDataContext : DbContext
    {
        public SetPointDataContext(DbContextOptions<SetPointDataContext> options) : base(options)
        {
        }

        public DbSet<SetPointData> SetPoints { get; set; }
    }
}
