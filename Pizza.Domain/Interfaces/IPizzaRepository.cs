using NendoPizza.Domain.Entities;

namespace NendoPizza.Domain.Interfaces
{
    public interface IPizzaRepository
    {
        public List<Pizza> GetPizzas();

        public Pizza GetPizza(int id);

        public int Create(Pizza pizza);

        public int Update(Pizza pizza);
    }

}
