using ANKSuperMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace ANKSuperMarket.Data
{
    public class MarketDbContext : DbContext
    {
        public MarketDbContext()
        {
        }

        public MarketDbContext(DbContextOptions<MarketDbContext> options) :base(options)
        {

        }
        public DbSet<Models.Urun> Urunler { get; set; }
    }
    
}
