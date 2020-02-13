using AdvancedWf.Data.Infrastructure;
using AdvancedWf.Data.Repositories;
using AdvancedWf.DTO;
using AdvancedWf.Model;
using AutoMapper;
 
  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedWf.Service
{
    // operations you want to expose
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> GetCategories(string name = null);
        CategoryViewModel GetCategory(int id);
        CategoryViewModel GetCategory(string name);
        void CreateCategory(CategoryViewModel category);
        void SaveCategory();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categorysRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categorysRepository, IUnitOfWork unitOfWork)
        {
            this.categorysRepository = categorysRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<CategoryViewModel> GetCategories(string name = null)
        {
            IEnumerable<Category> CategoryList;
             if (string.IsNullOrEmpty(name))
                CategoryList= categorysRepository.GetAll();
            else
                CategoryList= categorysRepository.GetAll().Where(c => c.Name == name);

            return Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(CategoryList);

        }

        public CategoryViewModel GetCategory(int id)
        {
            var category = categorysRepository.GetById(id);
            var categoryDTO = Mapper.Map<Category, CategoryViewModel>(category);

            return categoryDTO;
        }

        public CategoryViewModel GetCategory(string name)
        {
            var category = categorysRepository.GetCategoryByName(name);
            var categoryDTO = Mapper.Map<Category, CategoryViewModel>(category);

            return categoryDTO;
        }

        public void CreateCategory(CategoryViewModel categoryDTO)
        {
            var category = Mapper.Map<CategoryViewModel, Category>(categoryDTO);

            categorysRepository.Add(category);
        }

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
