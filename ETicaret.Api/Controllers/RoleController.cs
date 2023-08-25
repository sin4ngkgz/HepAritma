using ETicaret.Model;
using ETicaret.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace ETicaret.Api.Controllers
{
    [Authorize(Roles="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController
    {
       

        public RoleController(RepositoryWrapper repo, IMemoryCache cache): base (repo, cache) { }

        [HttpGet("AllRoles")]
        public dynamic AllRoles()
        {
            List<Role> items = repo.RoleRepository.FindAll().ToList<Role>();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpPost("Add")]

        public dynamic Add([FromBody]dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Role item = new Role()
            {
                Id = json.Id,
                Name = json.Name,
            };

            if (item.Id > 0) 
            {
                repo.RoleRepository.Update(item);   
            }
            else
            {
                repo.RoleRepository.Create(item);
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
            repo.RoleRepository.RoleDelete(id);
            return new
            {
                success = true
            };
        }

    }

    
}
