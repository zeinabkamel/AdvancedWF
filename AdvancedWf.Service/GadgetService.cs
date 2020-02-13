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
    public interface IGadgetService
    {
        IEnumerable<GadgetViewModel> GetGadgets();
        IEnumerable<GadgetViewModel> GetCategoryGadgets(string categoryName, string gadgetName = null);
        GadgetViewModel GetGadget(int id);
        void CreateGadget(GadgetFormViewModel gadget);
        void SaveGadget();
    }

    public class GadgetService : IGadgetService
    {
        private readonly IGadgetRepository gadgetsRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public GadgetService(IGadgetRepository gadgetsRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.gadgetsRepository = gadgetsRepository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IGadgetService Members

        public IEnumerable<GadgetViewModel> GetGadgets()
        {
            var gadgets = gadgetsRepository.GetAll();
            var returnedGadgat = Mapper.Map<IEnumerable<Gadget>, IEnumerable<GadgetViewModel>>(gadgets);

            return returnedGadgat;
        }

        public IEnumerable<GadgetViewModel> GetCategoryGadgets(string categoryName, string gadgetName = null)
        {
            var category = categoryRepository.GetCategoryByName(categoryName).Gadgets.Where(g => g.Name.ToLower().Contains(gadgetName.ToLower().Trim())); ;

             return   Mapper.Map<IEnumerable<Gadget>, IEnumerable<GadgetViewModel>>(category);

        }

        public GadgetViewModel GetGadget(int id)
        {

            var gadgetDTO = gadgetsRepository.GetById(id);
            var gadget = Mapper.Map<Gadget, GadgetViewModel>(gadgetDTO);

            return gadget;
        }

        public void CreateGadget(GadgetFormViewModel gadgetDTO)
        {
            var gadget = Mapper.Map<GadgetFormViewModel, Gadget>(gadgetDTO);

            gadgetsRepository.Add(gadget);
        }

        public void SaveGadget()
        {
            unitOfWork.Commit();
        }

 

        #endregion

    }
}
