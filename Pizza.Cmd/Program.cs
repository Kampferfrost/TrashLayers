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

            UddatePizza(pizzaRepository);
            GetPizzasAsync(pizzaRepository);
            AddPizza(pizzaRepository);
            GetPizzaById(pizzaRepository);
            GetPizzasAsync(pizzaRepository);
            DeletePizzaById(pizzaRepository);
        }

        private static void UddatePizza(IPizzaRepository? pizzaRepository)
        {
            var pizza = GetPizzaById(pizzaRepository);
            pizza.Name = "Monkey Pizza";
            pizzaRepository.Update(pizza);
        }

        private static void DeletePizzaById(IPizzaRepository? pizzaRepository)
        {
            if(pizzaRepository.DeletePizza(1) is 0)
            {
                Console.WriteLine("Запись НЕ удалина");
            }
            else
            {
                Console.WriteLine("Запись удалина");
            }

            GetPizzasAsync(pizzaRepository);
        }

        private static Pizza GetPizzaById(IPizzaRepository? pizzaRepository)
        {
            Console.WriteLine();
            Console.WriteLine("***Поиск пиццы по ИД***");
            Console.WriteLine();
            var foundPizza = pizzaRepository?.GetPizza(2);
            Console.WriteLine("Найденая пицца по ID:");
            Console.WriteLine($"Name: {foundPizza.Name}, Id:{foundPizza.Id}");
            Console.WriteLine();
            Console.WriteLine("___Конце поиска пиццы по ИД______");
            return foundPizza;
        }

        private static void AddPizza(IPizzaRepository? pizzaRepository)
        {
            pizzaRepository.Create(new Pizza() { Name = "Trololo lie trodo" });
        }

        private static async Task GetPizzasAsync(IPizzaRepository? pizzaRepository)
        {
            Console.WriteLine();
            Console.WriteLine("***Вывод всех пицц***");
            Console.WriteLine();
            var listNendoPizzas = await pizzaRepository?.GetPizzas();
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
