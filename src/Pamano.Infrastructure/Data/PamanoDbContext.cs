using Microsoft.EntityFrameworkCore;

namespace Pamano.Infrastructure.Data
{
    public class PamanoDbContext : DbContext
    {
        public PamanoDbContext(DbContextOptions<PamanoDbContext> options) : base(options)
        {

        }
        public int Rol { get; set; }
    }
}