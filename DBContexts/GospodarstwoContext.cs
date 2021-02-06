using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using AgroControl.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AgroControl.DBContexts
{
    public class GospodarstwoContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Gospodarstwo> Gospodarstwo { get; set; }
        public DbSet<ObiektGospodarczy> ObiektyGospodarcze { get; set; }

        public GospodarstwoContext(DbContextOptions<GospodarstwoContext> options)
            : base(options) { }
        public GospodarstwoContext() { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseLazyLoadingProxies()
        //        .UseNpgsql("conn_string");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gospodarstwo>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Nazwa).IsRequired();
                entity.Property(e => e.Wlasciciel).IsRequired();
            });
 
            modelBuilder.Entity<ObiektGospodarczy>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Nazwa).IsRequired();
                //entity.Property(e => e.GospodarstwoID).IsRequired();
            });

        }
    }
}