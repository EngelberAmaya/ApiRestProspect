using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.IO;
using System.Dynamic;

using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;




namespace ApiRestProspect.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // para configurar las claves conpuestas 
            modelBuilder.Entity<Software_Prospect>().HasKey(softprosp => new { softprosp.software_id, softprosp.prospect_id});


            //asignando las propiedades, para las relaciones de las claves compuestas
            
            modelBuilder.Entity<Software_Prospect>().HasOne(softprosp => softprosp.Software)
                                             .WithOne(softprosp => softprosp.Software_Prospect)
                                             .HasForeignKey<Software_Prospect>(softprosp => softprosp.software_id);
            
            modelBuilder.Entity<Software_Prospect>().HasOne(softprosp => softprosp.Prospect)
                                             .WithOne(softprosp => softprosp.Software_Prospect)
                                             .HasForeignKey<Software_Prospect>(softprosp => softprosp.prospect_id);
           

        }

        public DbSet<Software> Software { get; set; }
        public DbSet<Software_Prospect> Software_Prospect { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }

        public DbSet<User> User { get; set; }
    }

    
}
