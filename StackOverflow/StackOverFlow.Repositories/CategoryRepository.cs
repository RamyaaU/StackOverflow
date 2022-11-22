using System;
using System.Collections.Generic;
using System.Linq;
using StackOverFlow.DomainModels;
using StackOverFlow.Repositories.Interfaces;

namespace StackOverFlow.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StackOverflowDatabaseDbContext _context;

        public CategoryRepository(StackOverflowDatabaseDbContext context)
        {
            _context = context;
        }

        public void InsertCategory(Category c)
        {
            _context.Categories.Add(c);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category c)
        {
            Category category = _context.Categories.Where(x => x.CategoryId == c.CategoryId).FirstOrDefault();
            if(category != null)
            {
                category.CategoryId = c.CategoryId;
                _context.SaveChanges();
            }
        }

        public void DeleteCategory(int cid)
        {
            Category category = _context.Categories.Where(x => x.CategoryId == cid).FirstOrDefault();
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = _context.Categories.ToList();
            return categories;
        }

        public List<Category> GetCategoryByCategoryId(int categoryId)
        {
            List<Category> categories = _context.Categories.Where(x => x.CategoryId == categoryId).ToList();
            return categories;
        }
    }
}
