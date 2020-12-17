using HelpDesk.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Data { 
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Department>().HasOne(x => x.Admin);
            builder.Entity<Department>().HasMany(x => x.Users).WithOne(x => x.Department);
            builder.Entity<Ticket>().HasMany(x => x.TicketTimeLines).WithOne(x => x.Ticket);
            builder.Entity<Ticket>().HasMany(x => x.TicketFiles).WithOne(x => x.Ticket);
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketFiles> TicketFiles { get; set; }
        public DbSet<TicketTimeLine> TicketTimeLines { get; set; }
    }
}
