using NendoPizza.Domain.Entities;

namespace NendoPizza.Domain.Interfaces
{
    public interface IPizzaRepository
    {
        public Task<List<Pizza>> GetPizzas();

        public Pizza GetPizza(int id);

        public int CreatePizza(Pizza pizza);

        public int Update(Pizza pizza);
        public int DeletePizza(int id);
    }

}
