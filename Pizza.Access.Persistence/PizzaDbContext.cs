using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Entities;

namespace Pizza.Access.Persistence.Repositories
{
    public class PizzaDbContext : DbContext
    {
        public DbSet<PizzaEntity> Pizzas { get; set; }
        public PizzaDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Pizza.db");
        }

    }
}
