using NendoPizza.Access.Persistence.Repositories;
using NendoPizza.Domain.Entities;
using NendoPizza.Domain.Interfaces;

namespace NendoPizza.Access.Persistence
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzaDbContext _context;

        public PizzaRepository()
        {
            _context = new PizzaDbContext();
        }
        

        public int Create(Pizza pizza)
        {
            using var context = _context;
            context.Pizzas.Add(pizza);
            var count = context.SaveChanges();
            return count;
        }

        public List<Pizza> GetPizzas()
        {
            using var context = _context;
            return context.Pizzas.ToList();
        }

        public Pizza? GetPizza(int id)
        {
            using var contex = _context;
            return contex.Pizzas.Find(id);

        }
        public int Update(Pizza pizza)
        {
            using var context = _context;
            context.Update(pizza);
            var count = context.SaveChanges();
            return count;
        }

        public int DeletePizza(int id)
        {
            using var context = _context;
            var pizza = context.Pizzas.Find(id);
            var count = 0;
            if (pizza != null)
            {
                context.Pizzas.Remove(pizza);
                count = context.SaveChanges();
            }
            return count;
        }


    }
}
