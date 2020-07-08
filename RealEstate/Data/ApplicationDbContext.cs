using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<RealEstate.Models.Client> Client { get; set;}

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
                                              }
            );
        }
    }
}
