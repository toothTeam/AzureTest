using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SoloduhaMVC.Models.Content
{
    public class ContentDbContext : DbContext
    {
        public DbSet<Content> Contents { get; set; }
    }
}