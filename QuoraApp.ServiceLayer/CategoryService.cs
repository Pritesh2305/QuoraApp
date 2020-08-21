using AutoMapper;
using QuoraApp.DomainModels;
using QuoraApp.Repository;
using QuoraApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoraApp.ServiceLayer
{
    public interface ICategoryService
    {
        void InsertCategory(CategoryViewModel cvm);

        void UpdateCategory(CategoryViewModel cvm);

        void DeleteCategory(int cid);

        List<CategoryViewModel> GetCategories();

        List<CategoryViewModel> GetCategoriesByID(int cid);
    }

    public class CategoryService : ICategoryService
    {
        ICategoriesRepository cr;

        public CategoryService()
        {
            cr = new CategoriesRepository();
        }

        public void InsertCategory(CategoryViewModel cvm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, Category>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            Category c = mapper.Map<CategoryViewModel, Category>(cvm);
            cr.InsertCategory(c);            
        }

        public void UpdateCategory(CategoryViewModel cvm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, Category>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            Category c = mapper.Map<CategoryViewModel, Category>(cvm);
            cr.UpdateCategory(c);
        }

        public void DeleteCategory(int cid)
        {
            cr.DeleteCategory(cid);
        }

        public List<CategoryViewModel> GetCategories()
        {
            List<Category> c = cr.GetCategories();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            List<CategoryViewModel> cvm = mapper.Map<List<Category>, List<CategoryViewModel>>(c);

            return cvm;

        }

        public List<CategoryViewModel> GetCategoriesByID(int cid)
        {
            List<Category> c = cr.GetCategoriesByID(cid);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            List<CategoryViewModel> cvm = mapper.Map<List<Category>, List<CategoryViewModel>>(c);

            return cvm;

        }
    }

}
