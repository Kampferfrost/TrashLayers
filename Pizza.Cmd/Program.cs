using NendoPizza.Access.Persistence.Repositories;
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
            GetPizzas(pizzaRepository);


        }

        private static void GetPizzas(IPizzaRepository? pizzaRepository)
        {
            Console.WriteLine("_______________________________________________");
            var nendoPizzas = pizzaRepository?.GetPizzas();
            foreach (var pizza in nendoPizzas)
            {
                Console.WriteLine(pizza.Name);
                Console.WriteLine("***");
            }
            Console.WriteLine();
            Console.WriteLine("_______________________________________________");
            Console.WriteLine();
        }
    }
}
