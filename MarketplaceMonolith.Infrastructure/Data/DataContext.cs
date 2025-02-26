using MarketplaceMonolith.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceMonolith.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //буде створено таблицю в бд, під час виконання коду EF
        public DbSet<UserModel> ApplicationUser { get; set; }
    }
}
