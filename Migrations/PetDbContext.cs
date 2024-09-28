using midterm_project.Models;
using Microsoft.EntityFrameworkCore;

namespace midterm_project.Migrations;

public class PetDbContext : DbContext 
{
    public DbSet<Pet> Pets { get; set; }

    public PetDbContext(DbContextOptions<PetDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Pet>(entity =>
    {
        entity.HasKey(e => e.PetId);
        entity.Property(e => e.Name).IsRequired();
        entity.Property(e => e.ImgUrl).IsRequired();        
        entity.Property(e => e.Type).IsRequired();
        entity.Property(e => e.Description).IsRequired();
        entity.Property(e => e.Age).IsRequired();
        entity.Property(e => e.Price).IsRequired();
    });
}
}