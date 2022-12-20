using BOOKS.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BOOKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKS.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books {get;set;}
    public DbSet<Client> Clients {get;set;}
    public DbSet<Pagesa> Pagesa {get;set;}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // builder.Entity<Pagesa>().HasOne(a => a.Client).WithMany(b => b.Pagesa).HasForeignKey(c => c.ClientId).OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Client>().ToTable("Client");
        builder.Entity<Pagesa>().ToTable("Pagesa");

        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

    }
}
public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.Name).HasMaxLength(255);
        builder.Property(u => u.Surname).HasMaxLength(255);
    }
}
