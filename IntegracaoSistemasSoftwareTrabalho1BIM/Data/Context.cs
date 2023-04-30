using IntegracaoSistemasSoftwareTrabalho1BIM.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegracaoSistemasSoftwareTrabalho1BIM.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }
    
    public DbSet<RestaurantModel> Restaurants { get; set; }
    public DbSet<AddressModel> Addresses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<RestaurantModel>().HasKey(m => m.Id);
        builder.Entity<AddressModel>().HasKey(m => m.Id);
        builder.Entity<AddressModel>()
            .HasOne<RestaurantModel>(s => s.Restaurant)
            .WithMany(g => g.Addresses)
            .HasForeignKey(s => s.RestaurantId);

        base.OnModelCreating(builder);
    }
}