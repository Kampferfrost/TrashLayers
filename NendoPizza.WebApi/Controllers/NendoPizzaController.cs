using Microsoft.AspNetCore.Mvc;
using NendoPizza.Domain.Entities;
using NendoPizza.Domain.Interfaces;

namespace NendoPizza.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NendoPizzaController : ControllerBase
    {
        private readonly IPizzaRepository _pizzaRepository;
        public NendoPizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        //[HttpGet(Name = "GetPizzas")]
        //public ActionResult Get()
        //{
        //    var pizza = _pizzaRepository?.GetPizzas();
        //    return Ok(pizza);
        //}

        [HttpGet(Name = "GetPizzas")]
        public async Task<List<Pizza>> GetPizzas()
        {
            var pizza = await _pizzaRepository?.GetPizzas();
            return pizza;
        }

        [HttpPost(Name = "PostPizza")]
        public int CreatePizza(Pizza pizza)
        {
            var pizzaCheck = _pizzaRepository?.CreatePizza(pizza);
            //return pizza.Name ?? "No pizza";
            return pizzaCheck ?? 5;

        }
    }

    
}
