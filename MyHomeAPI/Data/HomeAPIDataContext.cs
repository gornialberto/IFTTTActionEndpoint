using Microsoft.EntityFrameworkCore;
using MyHomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Data
{
    public class HomeAPIDataContext : DbContext
    {
        public HomeAPIDataContext(DbContextOptions<HomeAPIDataContext> options) : base(options)
        {

        }

        public DbSet<SetPointData> SetPoints { get; set; }

        public DbSet<IFTTTActionData> IFTTTActionsData { get; set; }

        public DbSet<ManifoldsData> ManifoldsData { get; set; }
    }
}
