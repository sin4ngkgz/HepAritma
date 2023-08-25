using ETicaret.Model;
using ETicaret.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace ETicaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {


        public ProductController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache){ }

        [HttpGet("AllProducts")]
        public dynamic AllProducts()
        {
            List<Product> items = repo.ProductRepository.FindAll().ToList<Product>();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("GetProduct/{id}")]
        public dynamic Get(int id)
        {
            Product item = repo.ProductRepository.FindByCondition(a => a.Id == id).SingleOrDefault<Product>();
            return new
            {
                success = true,
                data = item
            };
        }

        [HttpPost("Add")]

        public dynamic Add([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Product item = new Product()
            {
                Id = json.Id,
                Name = json.Name,
                Description = json.Description,
                Title = json.Title,
                Price = json.Price
            };

            if (item.Id > 0)
            {
                repo.ProductRepository.Update(item);
            }
            else
            {
                repo.ProductRepository.Create(item);
            }

            repo.SaveChanges();

            return new
            {
                success = true
            };
        }

        [HttpDelete("Delete")]
        public dynamic Delete(int id)
        {
            if (id <= 0)
            {
                return new
                {
                    success = false,
                    message = "Geçersiz Id"
                };
            }
            repo.ProductRepository.ProductDelete(id);
            return new
            {
                success = true
            };
        }

        [HttpGet("/{categoryId}")]

        public dynamic Products(int categoryId)
        {
            List<Product> items = repo.ProductRepository.GetProductsByCategoryId(categoryId);

            return new
            {
                success = true,
                data = items
            };
        }
    }
}
