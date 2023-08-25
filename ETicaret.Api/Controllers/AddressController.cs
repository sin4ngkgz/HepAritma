using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ETicaret.Model;
using ETicaret.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using ETicaret.Model.Views;

namespace ETicaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseController
    {
        public AddressController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache) { }

        [HttpPost("Add")]

        public dynamic Add([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Address item = new Address()
            {
                Id = json.Id,
                UserId = json.UserId,
                FirstName = json.FirstName,
                LastName = json.LastName,
                AddressName = json.AddressName,
                Description = json.Description,
                CountryId = json.CountryId,
                CityId = json.CityId,
                DistrictId = json.DistrictId,
                ZipCode = json.ZipCode

            };

            if (item.Id > 0)
            {
                repo.AddressRepository.Update(item);
            }
            else
            {
                repo.AddressRepository.Create(item);
            }

            repo.SaveChanges();

            return new
            {
                success = true
            };
        }

        [HttpGet("AllAddresses")]
        public dynamic AllAddresses()
        {
            List<Address> items = repo.AddressRepository.FindAll().ToList<Address>();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("AddressListByUserId")]
        public dynamic GetAddressListByUserId(int id)
        {
            List<V_AddressList> items = repo.AddressRepository.GetAddressListById(id);
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("GetDistricts")]
        public dynamic GetDistricts()
        {
            List<District> items = repo.AddressRepository.GetDistricts();

            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("GetCountries")]
        public dynamic GetCountries()
        {
            List<Country> items = repo.AddressRepository.GetCountries();

            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("GetCities")]
        public dynamic GetCities()
        {
            List<City> items = repo.AddressRepository.GetCities();

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
            repo.AddressRepository.AddressDelete(id);
            return new
            {
                success = true
            };
        }

    }
}
