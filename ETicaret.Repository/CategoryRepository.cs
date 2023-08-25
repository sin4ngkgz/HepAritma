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
    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {

        }
        public List<Category> GetCategoryMainMenus()
        {
            List<Category> categoryMainMenus = (from k in RepositoryContext.Categories.Include(a => a.TopCategory)
                                                join a in RepositoryContext.CategoryMainMenus on k.Id equals a.CategoryId
                                                select k).ToList<Category>();
            return categoryMainMenus;
        }

        public List<V_CategoryList> CategoryList() => RepositoryContext.CategoryList.OrderBy(k=>k.Place).ToList<V_CategoryList>();

        public void CategoryDelete(int categoryId)
        {
            RepositoryContext.Categories.Where(r => r.Id == categoryId).ExecuteDelete();
        }
    }
}
