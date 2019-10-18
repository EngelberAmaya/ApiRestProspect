using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.IO;
using System.Dynamic;


namespace ApiRestProspect.Models
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        public DbSet<Prospect> Prospect { get; set; }
        public DbSet<Software> Software { get; set; }
        public DbSet<Software_Prospect> Software_Prospect { get; set; }
        public DbSet<User> User { get; set; }
    }

    
}
