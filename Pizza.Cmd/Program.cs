using Pizza.Access.Persistence.Repositories;
using Pizza.Domain.Entities;

namespace Pizza.Cmd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (PizzaDbContext GetContextPizza = new PizzaDbContext())
            {
                PizzaEntity classicItalian = new PizzaEntity() { Name = "Classic Italian" };
                PizzaEntity veggie = new PizzaEntity() { Name = "Veggie" };
                PizzaEntity skoofoniy = new PizzaEntity() { Name = "Пицца От скуффа" };

                GetContextPizza.Pizzas.Add(classicItalian);
                GetContextPizza.Pizzas.Add(veggie);
                GetContextPizza.Pizzas.Add(skoofoniy);
                GetContextPizza.SaveChanges();

                Console.WriteLine("Объекты успешно сохранены");

                var pizzas = GetContextPizza.Pizzas.ToList();
                Console.WriteLine("Список:");
                foreach (var pizza in pizzas)
                {
                    Console.WriteLine($"{pizza.Name}");
                    Console.WriteLine("_____________");
                }

            }
        }
    }
}
