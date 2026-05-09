using Microsoft.EntityFrameworkCore;
using UserManegment.Entities;

namespace UserManegment;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; } = null!;
    
}