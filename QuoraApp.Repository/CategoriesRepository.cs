using QuoraApp.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoraApp.Repository
{

    public interface ICategoriesRepository
    {
        void InsertCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(int cid);

        List<Category> GetCategories();

        List<Category> GetCategoriesByID(int cid);

    }

    public class CategoriesRepository : ICategoriesRepository
    {
        QuoraDBDataContext dc;

        public CategoriesRepository()
        {
            dc = new QuoraDBDataContext();
        }

        public void DeleteCategory(int cid)
        {
            dc.Categories.Remove(dc.Categories.Find(cid));            
        }

        public List<Category> GetCategories()
        {
            List<Category> Categories = (from p in dc.Categories
                                         orderby p.CategoryName
                                         select p
                                         ).ToList();
            return Categories;
        }

        public List<Category> GetCategoriesByID(int cid)
        {
            List<Category> Categories = (from p in dc.Categories
                                         where p.CategoryID == cid
                                         select p
                                         ).ToList();
            return Categories;

        }

        public void InsertCategory(Category category)
        {
            dc.Categories.Add(category);
            dc.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            Category exisitingcategory = (from p in dc.Categories
                                          where p.CategoryID == category.CategoryID
                                          select p
                                          ).FirstOrDefault();

            if (exisitingcategory != null)
            {
                exisitingcategory.CategoryName = category.CategoryName;
                dc.SaveChanges();
            }            
        }
    }
}
