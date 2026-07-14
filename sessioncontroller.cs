using APISession.Models;
using Microsoft.AspNetCore.Mvc;

namespace APISession.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private static List<string> products = new()
        {
            "Mobile",
            "CPU",
            "Speaker"
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= products.Count)
                return NotFound();

            return Ok(products[id]);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            products.Add(product.Name);
            return Ok($"{product.Name} Added Successfully");
        }
    }
}
