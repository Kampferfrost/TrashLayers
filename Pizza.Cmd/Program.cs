using NendoPizza.Access.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using NendoPizza.Domain.Interfaces;
using NendoPizza.Access.Persistence;
using NendoPizza.Domain.Entities;

namespace NendoPizza.Cmd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<PizzaDbContext>();
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            var serviceProvider = services.BuildServiceProvider();

            var pizzaRepository = serviceProvider?.GetService<IPizzaRepository>();
            GetPizzas(pizzaRepository);

            pizzaRepository.Create(new Pizza() {Name = "Trololo lie trodo" });

            GetPizzas(pizzaRepository);
        }

        private static void GetPizzas(IPizzaRepository? pizzaRepository)
        {
            Console.WriteLine("_______________________________________________");
            var listNendoPizzas = pizzaRepository?.GetPizzas();
            foreach (var pizza in listNendoPizzas)
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
