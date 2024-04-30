using ClassLibrary.Business;
using ClassLibrary.Business.Entities;
using ClassLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiYens.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductData productData = new ProductData();

        // GET: api/Product
        [HttpGet]
        public ActionResult GetAllProducts()
        {
            var result = productData.Select();

            if (result.Succeeded)
            {
                List<Product> productList = Products.MakeListFromDataTable(result.DataTable);
                string JSONresult = JsonConvert.SerializeObject(productList);
                return Ok(JSONresult);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result.Errors);
            }
        }
        // GET: api/Product/{id}
        [HttpGet("{id}")]
        public ActionResult GetProductById(int id)
        {
            // Implementation for fetching a product by its ID
            var result = productData.GetProductById(id);

            if (result.Succeeded && result.DataTable.Rows.Count > 0)
            {
                var product = Products.MakeListFromDataTable(result.DataTable).FirstOrDefault();
                return Ok(product);
            }
            else if (result.Succeeded)
            {
                return NotFound("Product not found.");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result.Errors);
            }
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {




            var result = Products.AddProduct(product.ProductName, product.ProductDescription, product.PricePerUnit, product.Stock, product.Category, product.Size);
            if (result.Succeeded)
            {
                return Ok();
            }

            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
