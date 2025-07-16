using API.Entities;
using API.Entities.OrderAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class StoreContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public required DbSet<Product> Products { get; set; }
    public required DbSet<Basket> Baskets { get; set; }
    public required DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole { Id = "b931dec2-bf81-436f-a8e5-f33143315e95", Name = "Member", NormalizedName = "MEMBER" },
                new IdentityRole { Id = "f6c67efb-a55b-4345-b540-190fec42d063", Name = "Admin", NormalizedName = "ADMIN" }
            );
    }
}
