using AdvancedWf.Data.Infrastructure;
using AdvancedWf.DTO;
using AdvancedWf.Model;
using AdvancedWf.Model.Models;
using AdvancedWf.Shared.ViewModels;
using AdvancedWf.Shared.ViewModels.DataTable;
using System;
using System.Linq;
 
 

namespace AdvancedWf.Data.Repositories
{
    public class WorkflowTypesRepository : AdvancedWf.Data.Infrastructure.RepositoryBase<WorkflowTypes>, IWorkflowTypesRepository
    {
        public WorkflowTypesRepository(IDbFactory dbFactory)
            : base(dbFactory) { }





        #region DataTable
        /// <summary>
        /// get collection of WorkflowType sorted based on  DatatableParams Order , OrderDir properties
        /// </summary>
        /// <param name="viewModel">Datatable filter/paging/sort details</param>
        /// <param name="cols">WorkflowType fields used for sorting</param>
        /// <param name="lst">collection of WorkflowType </param>
        /// <returns>sorted collection of WorkflowType</returns>
        private IQueryable<WorkflowTypesDTO> GetListSorted(DatatableParams viewModel, string[] cols, IQueryable<WorkflowTypesDTO> lst)
        {
            var orderField = cols[int.Parse(viewModel.order)] == "StatusName" ? "Status" : cols[int.Parse(viewModel.order)];
            if (viewModel.orderDir == null || viewModel.orderDir == "asc")
            {
                lst = lst.OrderBy(orderField);
            }
            else if (viewModel.orderDir != null && viewModel.orderDir == "desc")
            {
                lst = lst.OrderByDescending(orderField);
            }
            else
            {
                lst = lst.OrderByDescending(a => a.Id);
            }

            return lst;
        }

        /// <summary>
        /// get collection of WorkflowType filtered based on DatatableParams Search property
        /// </summary>
        /// <param name="viewModel">Datatable filter/paging/sort details</param>
        /// <param name="lst">collection of WorkflowType</param>
         /// <returns>filtered collection of WorkflowType</returns>
        private IQueryable<WorkflowTypesDTO> GetListSearched(DatatableParams viewModel, IQueryable<WorkflowTypesDTO> lst)
        {
            if (!string.IsNullOrEmpty(viewModel.search))
            {
                lst = lst
                .Where(a => a.Id.ToString().Contains(viewModel.search) ||
                 a.ArbicName.ToLower().Contains(viewModel.search.ToLower()) ||
                a.EnglishName.ToLower().Contains(viewModel.search.ToLower())
            );
            }

             return lst;
        }
        public DatatableResult GetDatatableList(DatatableParams viewModel)
        {
            string[] cols = { "Id", "ArabicName", "EnglishName" };

            var start = GetStart(viewModel.startString);
            var length = GetLength(viewModel.endString);

            var lst = GetList();

            lst = GetListSearched(viewModel, lst);
            lst = GetListSorted(viewModel, cols, lst);

            var count = lst.Count();
            var data = lst.Skip(start).Take(length).ToList();
            var oResult = new  DatatableResult
            {
                draw = viewModel.nDraw
            };
            foreach (var item in data)
            {
                 oResult.data.Add(item);

            }

            oResult.recordsTotal = count;
            oResult.recordsFiltered = count;
            return oResult;
        }

        public IQueryable<WorkflowTypesDTO> GetList()
        {
            return DbContext.WorkflowTypes
                .AsNoTracking()
                    .Select(a => new WorkflowTypesDTO
                    {
                        Id = a.Id,
                        ArbicName = a.ArabicName,
                        EnglishName = a.EnglishName,
                        CreationDate = a.CreationDate,
                        ModificationDate = a.ModificationDate
                    });
        }

        #endregion
    }

    public interface IWorkflowTypesRepository : IRepository<WorkflowTypes>
    {
        DatatableResult GetDatatableList(DatatableParams viewModel);

    }
}
