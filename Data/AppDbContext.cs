using Microsoft.EntityFrameworkCore;
using apbd_10.Models;

namespace apbd_10.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<AppUser> AppUsers => Set<AppUser>();
    public DbSet<UserNote> UserNotes => Set<UserNote>();
}