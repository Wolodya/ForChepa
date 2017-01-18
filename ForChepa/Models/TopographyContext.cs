using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace ForChepa.Models
{
    public class TopographyContext:DbContext
    {
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Third> Third { get; set; }
    }
}