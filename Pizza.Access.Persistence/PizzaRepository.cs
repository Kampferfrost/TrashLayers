using NendoPizza.Access.Persistence.Repositories;
using NendoPizza.Domain.Entities;
using NendoPizza.Domain.Interfaces;

namespace NendoPizza.Access.Persistence
{
    // это временная реализация
    // потом нормально вынесу 
    public class PizzaRepository : IPizzaRepository
    {
        private PizzaDbContext pizzaDbContext = new PizzaDbContext();
        public List<Pizza> GetPizzas()
        {
            using var context = pizzaDbContext;
            return context.Pizzas.ToList();
        }

    }
}
