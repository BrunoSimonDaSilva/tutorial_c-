using Microsoft.EntityFrameworkCore;
using selecao.Models;

namespace selecao.Data
{
    public class BaseContext: DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }
        public DbSet<Time> Time { get; set; }
    }
}
