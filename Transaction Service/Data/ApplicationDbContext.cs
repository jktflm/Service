using Microsoft.EntityFrameworkCore;
using Transaction_Service.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Transactions> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transactions>()
            .Property(t => t.Amount)
            .HasColumnType("decimal(18, 2)"); // Adjust precision and scale as per your requirements

        // Add other configurations here if needed

        base.OnModelCreating(modelBuilder);
    }
}
