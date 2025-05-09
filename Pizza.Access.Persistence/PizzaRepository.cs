using NendoPizza.Access.Persistence.Repositories;
using NendoPizza.Domain.Entities;
using NendoPizza.Domain.Interfaces;

namespace NendoPizza.Access.Persistence
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzaDbContext _context;

        public PizzaRepository(PizzaDbContext context)
        {
            _context = context;
        }
        

        public int CreatePizza(Pizza pizza)
        {
            pizza.Id = _context.Pizzas.Count() + 1; 
            _context.Pizzas.Add(pizza);
            
            var count = _context.SaveChanges();
            return count;

        }

        public async Task<List<Pizza>> GetPizzas()
        {
            return _context.Pizzas.ToList();
        }

        public Pizza? GetPizza(int id)
        {
            return _context.Pizzas.Find(id);
        }
        public int Update(Pizza pizza)
        {
            _context.Update(pizza);
            var count = _context.SaveChanges();
            return count;
        }

        public int DeletePizza(int id)
        {
            var pizza = _context.Pizzas.Find(id);
            var count = 0;
            if (pizza != null)
            {
                _context.Pizzas.Remove(pizza);
                count = _context.SaveChanges();
            }
            return count;
        }


    }
}
