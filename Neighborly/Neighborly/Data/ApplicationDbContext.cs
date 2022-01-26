using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Neighborly.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neighborly.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        DbSet<Event> Events { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
