using NendoPizza.Access.Persistence.Repositories;
using NendoPizza.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using NendoPizza.Domain.Interfaces;
using NendoPizza.Access.Persistence;

namespace NendoPizza.Cmd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<PizzaDbContext>();
            services.AddSingleton<IPizzaRepository, PizzaRepository>();
            var serviceProvider = services.BuildServiceProvider();

            var pizzaRepository = serviceProvider?.GetService<IPizzaRepository>();

            Console.WriteLine("Вывод с репозитории");
            Console.WriteLine();

            var nendoPizzas = pizzaRepository?.GetPizzas();
            foreach (var pizza in nendoPizzas)
            {
                Console.WriteLine(pizza.Name);
                Console.WriteLine("***");
            }
            Console.WriteLine();
            Console.WriteLine("Конец работы с репозиторием");
            Console.WriteLine(); 
            Console.WriteLine();

            using (var scope = serviceProvider?.CreateScope())
            {
                var pizzaDbContext = scope.ServiceProvider?.GetService<PizzaDbContext>();
                
                

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
