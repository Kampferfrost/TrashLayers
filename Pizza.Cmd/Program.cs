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
            AddPizza(pizzaRepository);
            GetPizzaById(pizzaRepository);
            GetPizzas(pizzaRepository);
        }

        private static void GetPizzaById(IPizzaRepository? pizzaRepository)
        {
            Console.WriteLine();
            Console.WriteLine("***Поиск пиццы по ИД***");
            Console.WriteLine();
            var foundPizza = pizzaRepository?.GetPizza(2);
            Console.WriteLine(foundPizza.Name);
            Console.WriteLine("Найденая пицца по ID:");
            Console.WriteLine();
            Console.WriteLine("___Конце поиска пиццы по ИД___");
        }

        private static void AddPizza(IPizzaRepository? pizzaRepository)
        {
            pizzaRepository.Create(new Pizza() { Name = "Trololo lie trodo" });
        }

        private static void GetPizzas(IPizzaRepository? pizzaRepository)
        {
            Console.WriteLine();
            Console.WriteLine("***Вывод всех пицц*****************************");
            Console.WriteLine();
            var listNendoPizzas = pizzaRepository?.GetPizzas();
            foreach (var pizza in listNendoPizzas)
            {
                Console.WriteLine(pizza.Name);
                Console.WriteLine("###");
            }
            Console.WriteLine();
            Console.WriteLine("___Конец вывода________________________________");
            Console.WriteLine();
        }
    }
}
