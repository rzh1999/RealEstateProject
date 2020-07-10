using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Models;

namespace RealEstate.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole
                                            {Name = "Client",
                                            NormalizedName = "CLIENT"},

                                            new IdentityRole
                                            {
                                                Name = "Realtor",
                                                NormalizedName = "REALTOR"
                                            },

                                             new IdentityRole
                                             {
                                                 Name = "LoanOfficer",
                                                 NormalizedName = "LOANOFFICER"
                                             },
                                              new IdentityRole
                                              {
                                                  Name = "Closing",
                                                  NormalizedName = "CLOSING"
                                              },
                                              new IdentityRole
                                              {
                                                  Name = "Admin",
                                                  NormalizedName = "ADMIN"
                                              }
            );
        }

        public DbSet<RealEstate.Models.Realtor> Realtor { get; set; }
        public DbSet<RealEstate.Models.Client> Client { get; set; }
        public DbSet<RealEstate.Models.Checklist> Checklist { get; set; }

        public DbSet<RealEstate.Models.LoanOfficer> LoanOfficer { get; set; }
        public DbSet<RealEstate.Models.ClosingRep> ClosingRep { get; set; }
        public DbSet<RealEstate.Models.Address> Address { get; set; }

    }

}
