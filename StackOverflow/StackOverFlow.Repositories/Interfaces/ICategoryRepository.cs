using StackOverFlow.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverFlow.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        void InsertCategory(Category c);

        void UpdateCategory(Category c);

        void DeleteCategory(int cid);

        List<Category> GetCategories();

        List<Category> GetCategoryByCategoryId(int categoryId);

    }
}
