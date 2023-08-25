using ETicaret.Api.Code.Validations;
using ETicaret.Model;
using ETicaret.Model.Views;
using ETicaret.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System;
using static ETicaret.Model.Enums;

namespace ETicaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        
        }

        [HttpGet("User")]

        public dynamic User()
        {
            List<User> items = repo.UserRepository.FindAll().ToList<User>();
            return new
            {
                sucess = true,
                data = items
            };
        }
        //[Authorize(Roles ="Admin")]
        [HttpGet("ActiveUsers")]

        public dynamic ActiveUsers()
        {
            List<V_ActiveUsers> items = repo.UserRepository.GetActiveUsers();
            return new
            {
                success = true,
                data = items
            };
            
        }

        [HttpPost("SignUp")]

        public dynamic SignUp([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

           
            string firstName = json.FirstName;
            string lastName = json.LastName;
            string phoneNumber = json.PhoneNumber;
            string email = json.Email;
            string password = json.Password;
            

            User item = new User()
            {
                Active = true,
                FirstName = json.FirstName,
                LastName = json.LastName,
                PhoneNumber = json.PhoneNumber,
                Email = json.Email,
                Password = json.Password,
                RoleId = Enums.Roles.Customer
            };

            User? user = repo.UserRepository.FindByCondition(k => k.Email == item.Email).SingleOrDefault<User>();
            if (user == null) 
            {
                UserValidator validator = new UserValidator();
                validator.ValidateAndThrow(item);

                repo.UserRepository.Create(item);
                repo.SaveChanges();

                return new
                {
                    success = true
                };
            }
            else
            {
                return new
                {
                    success = false,
                    message = "Böyle bir kullanıcı zaten var."
                };
            }

           
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
            repo.UserRepository.UserDelete(id);
            return new
            {
                success = true
            };
        }
    }
}
