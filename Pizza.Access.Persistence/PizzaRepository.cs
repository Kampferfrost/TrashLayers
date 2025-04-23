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

        public int Create(Pizza pizza)
        {
            using var context = pizzaDbContext;
            context.Pizzas.Add(pizza);
            var count = context.SaveChanges();
            return 1;
        }

        public Pizza GetPizza(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetPizzas()
        {
            using var context = pizzaDbContext;
            return context.Pizzas.ToList();
        }

        public int Update(Pizza pizza)
        {
            throw new NotImplementedException();
        }
    }
}
