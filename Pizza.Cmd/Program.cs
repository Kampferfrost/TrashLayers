using NendoPizza.Access.Persistence.Repositories;
using NendoPizza.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace NendoPizza.Cmd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<PizzaDbContext>();
            var serviceProvider = services.BuildServiceProvider();

            Pizza classicItalian = new Pizza() { Name = "Classic Italian" };
            Pizza veggie = new Pizza() { Name = "Veggie" };
            Pizza skoofoniy = new Pizza() { Name = "Пицца От скуффа" };

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
