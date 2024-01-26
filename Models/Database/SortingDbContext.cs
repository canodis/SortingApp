using Microsoft.EntityFrameworkCore;

public class SortingDbContext : DbContext
{
    public DbSet<SortingHistory> SortingHistories { get; set; }

    public SortingDbContext(DbContextOptions<SortingDbContext> options) : base(options)
    {
    }
}
