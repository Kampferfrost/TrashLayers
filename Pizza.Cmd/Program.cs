using Pizza.Access.Persistence.Repositories;
using Pizza.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Pizza.Cmd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<PizzaDbContext>();
            var serviceProvider = services.BuildServiceProvider();

            PizzaEntity classicItalian = new PizzaEntity() { Name = "Classic Italian" };
            PizzaEntity veggie = new PizzaEntity() { Name = "Veggie" };
            PizzaEntity skoofoniy = new PizzaEntity() { Name = "Пицца От скуффа" };

            using (var scope = serviceProvider?.CreateScope())
            {
                var pizzaDbContext = scope.ServiceProvider?.GetService<PizzaDbContext>();
                
                

                pizzaDbContext.Pizzas.Add(classicItalian);
                pizzaDbContext.Pizzas.Add(veggie);
                pizzaDbContext.Pizzas.Add(skoofoniy);
                pizzaDbContext.SaveChanges();

                Console.WriteLine("Объекты успешно сохранены");

                var pizzas = pizzaDbContext.Pizzas.ToList();
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
