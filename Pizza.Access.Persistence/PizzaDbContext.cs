using Microsoft.EntityFrameworkCore;
using NendoPizza.Domain.Entities;

namespace NendoPizza.Access.Persistence.Repositories
{
    public class PizzaDbContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public PizzaDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../Shared/Pizza.db"); //не прокатило
        }

    }
}
