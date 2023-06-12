using ExcalibCQRS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcalibCQRS.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
}