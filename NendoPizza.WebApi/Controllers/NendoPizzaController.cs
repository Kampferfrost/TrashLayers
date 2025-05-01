using Microsoft.AspNetCore.Mvc;
using NendoPizza.Access.Persistence;
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

        [HttpGet(Name = "GetPizza")]
        public ActionResult Get() // как я полагаю тут нужно указать явно
        {
            var pizza = _pizzaRepository.GetPizza(1);
            
            return Ok(pizza);
        }
    }

    
}
