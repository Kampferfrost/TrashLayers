using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Entities;

namespace Pizza.Access
{
    public class PizzaDbContext : DbContext
    {
        public DbSet<PizzaEntity> MyProperty { get; set; }
        public PizzaDbContext()
        {
            Database.EnsureCreated();
        }
    }
}
