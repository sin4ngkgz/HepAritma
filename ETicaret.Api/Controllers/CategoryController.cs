using ETicaret.Model;
using ETicaret.Model.Views;
using ETicaret.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace ETicaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        

        public CategoryController(RepositoryWrapper repo, IMemoryCache cache): base (repo, cache) { }

        [HttpGet("AllCategories")]

        public dynamic AllCategories()
        {

            List<Category> items;

            if (!cache.TryGetValue("AllCategories", out items))
            {
                items = repo.CategoryRepository.FindAll().ToList<Category>();
                cache.Set("AllCategories", items, DateTimeOffset.UtcNow.AddSeconds(20));
            }

            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("CategoryList")]
        [Authorize(Roles ="Admin")]
        public dynamic CategoryList() 
        {
            List<V_CategoryList> items = repo.CategoryRepository.CategoryList();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpPost("AddCategories")]

        public dynamic AddCategories([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Category item = new Category()
            {
                Id = json.Id,
                Name = json.Name,
                TopCategoryId = json.TopCategoryId,
                Photo = json.Photo,
                Active = json.Active,
                Place = json.Place
            };

            if (item.Id > 0)
                repo.CategoryRepository.Update(item);
            else
                repo.CategoryRepository.Create(item);

            repo.SaveChanges();

            cache.Remove("AllCategories");

            return new
            {
                success = true
            };



        }

        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            Category item = repo.CategoryRepository.FindByCondition(a => a.Id == id).SingleOrDefault<Category>();
            return new
            {
                success = true,
                data = item
            };
        }

        [HttpGet("TopCategories")]
        public dynamic TopCategories()
        {
            List <Category> items = repo.CategoryRepository.FindByCondition(a => a.TopCategoryId == null).ToList<Category>();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("SubCategories/{id}")]
        public dynamic SubCategories(int id)
        {
            List<Category> items = repo.CategoryRepository.FindByCondition(a => a.TopCategoryId == id).ToList<Category>();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("CategoryMainMenus")]
        public dynamic CategoryMainMenus()
        {
            List<Category> items = repo.CategoryRepository.GetCategoryMainMenus();
            return new
            {
                success = true,
                data = items
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
            repo.CategoryRepository.CategoryDelete(id);
            return new
            {
                success = true
            };
        }
    }
}
