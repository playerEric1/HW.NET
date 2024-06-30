using ApplicationCore;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Data;

public class EShopAPIContext : DbContext
{
    public EShopAPIContext(DbContextOptions<EShopAPIContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customer { get; set; } = default!;
}