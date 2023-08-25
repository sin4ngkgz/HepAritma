using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    public class RepositoryWrapper
    {
        private RepositoryContext context;

        private CategoryRepository categoryRepository;
        private RoleRepository roleRepository;
        private UserRepository userRepository;
        private ProductRepository productRepository;
        private AddressRepository addressRepository;
        

        public RepositoryWrapper(RepositoryContext context)
        { 
            this.context = context;
        }

        public CategoryRepository CategoryRepository
        { 
            get
            {
                if(categoryRepository == null)
                    categoryRepository = new CategoryRepository(context);
                return categoryRepository;
            }
        }
        public RoleRepository RoleRepository
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(context);
                return roleRepository;
            }
        }
        public UserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(context);
                return userRepository;
            }
        }
        public ProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(context);
                return productRepository;
            }
        }
        public AddressRepository AddressRepository
        {
            get
            {
                if (addressRepository == null)
                    addressRepository = new AddressRepository(context);
                return addressRepository;
            }
        }




        public void SaveChanges()
        {
            context.SaveChanges();
        }

        
    }
}
