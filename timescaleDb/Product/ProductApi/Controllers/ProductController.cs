using Microsoft.AspNetCore.Mvc;
using ProductData.Model;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductDbContext _productDbContext;

        public ProductController(ProductDbContext productDbContext) => _productDbContext = productDbContext;

        [HttpGet]
        public IActionResult GetProduct()
        {
            var products = _productDbContext.Products.ToList();
            return Ok(products);
        }


        [HttpPost]
        public IActionResult Index()
        {
            var product = new Product
            {
                Title = "Do Laundry!",
                Body = "You're laaundry is loking a little sad."
            };

            _productDbContext.Add(product);
            _productDbContext.SaveChanges();

            return View("Succesfully created a todo item!");
        }
    }
}
