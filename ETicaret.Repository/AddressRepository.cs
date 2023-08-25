using ETicaret.Model;
using ETicaret.Model.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    public class AddressRepository : RepositoryBase<Address>
    {
        public AddressRepository(RepositoryContext context) : base(context)
        {

        }
        public void AddressDelete(int addressId)
        {
            RepositoryContext.Addresses.Where(r => r.Id == addressId).ExecuteDelete();
        }
        public List<V_AddressList> GetAddressListById(int id) 
        {
            return RepositoryContext.AddressList.Where(a => a.UserId == id).ToList<V_AddressList>();
        }
        public List<City> GetCities()
        {
            return RepositoryContext.Cities.ToList<City>();
        }

        public List<Country> GetCountries()
        {
            return RepositoryContext.Countries.ToList<Country>();
        }

        public List<District> GetDistricts()
        {
            return RepositoryContext.Districts.ToList<District>();
        }
    }
}
