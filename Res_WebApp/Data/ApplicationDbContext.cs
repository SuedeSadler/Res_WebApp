using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Res_WebApp.Models;

namespace Res_WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Res_WebApp.Models.Reservations>? Reservations { get; set; }
        public DbSet<Res_WebApp.Models.Users>? Users { get; set; }
        public DbSet<Res_WebApp.Models.Menu>? Menu { get; set; }
    }
}