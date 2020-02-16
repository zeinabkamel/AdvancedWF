using AdvancedWf.Data.Infrastructure;
using AdvancedWf.Data.Repositories;
using AdvancedWf.DTO;
using AdvancedWf.Model;
using AdvancedWf.Model.Models;
using AdvancedWf.Shared.ViewModels.DataTable;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedWf.Service
{
    // operations you want to expose
    public interface IWorkflowtypesService
    {
         IEnumerable<WorkflowTypesDTO> GetWorkflowtypes();
         WorkflowTypesDTO GetWorkflowTypeyId(int id);
         void CreateWorkflowType(WorkflowTypesDTO WorkflowType);
         void EditWorkflowType(WorkflowTypesDTO WorkflowTypeDTO);
         void SaveWorkflowType();
        string GetList(DatatableParams param);

    }

    public class WorkflowtypesService : IWorkflowtypesService
    {
        private readonly IWorkflowTypesRepository WorkflowtypesRepository;
         private readonly IUnitOfWork unitOfWork;

        public WorkflowtypesService(IWorkflowTypesRepository WorkflowtypesRepository, IUnitOfWork unitOfWork)
        {
            this.WorkflowtypesRepository = WorkflowtypesRepository;
             this.unitOfWork = unitOfWork;
        }

        #region IWorkflowtypeservice Members

        public IEnumerable<WorkflowTypesDTO> GetWorkflowtypes()
        {
            var Workflowtypes = WorkflowtypesRepository.GetAll();
            var returnedWorkflowType = Mapper.Map<IEnumerable<WorkflowTypes>, IEnumerable<WorkflowTypesDTO>>(Workflowtypes);

            return returnedWorkflowType;
        }

        

        public WorkflowTypesDTO GetWorkflowTypeyId(int id)
        {

            var WorkflowTypeDTO = WorkflowtypesRepository.GetById(id);
            var WorkflowType = Mapper.Map<WorkflowTypes, WorkflowTypesDTO>(WorkflowTypeDTO);

            return WorkflowType;
        }

        public void CreateWorkflowType(WorkflowTypesDTO WorkflowTypeDTO)
        {
            var WorkflowType = Mapper.Map<WorkflowTypesDTO, WorkflowTypes>(WorkflowTypeDTO);

            WorkflowtypesRepository.Add(WorkflowType);
        }


        public void EditWorkflowType(WorkflowTypesDTO WorkflowTypeDTO)
        {
            var WorkflowType = Mapper.Map<WorkflowTypesDTO, WorkflowTypes>(WorkflowTypeDTO);

            WorkflowtypesRepository.Update(WorkflowType);
        }

        public void SaveWorkflowType()
        {
            unitOfWork.Commit();
        }



        #endregion

        #region WorkFlowTypes
        public string GetList(DatatableParams param )
        {
            try
            {
                
                     var result = WorkflowtypesRepository.GetDatatableList(param);
                    return JsonConvert.SerializeObject(result);
               
            }
            catch (Exception e)
            {
                new ErrorLogsRepository().AddErrorLog(e.ToString(), null, e);
            }
            return string.Empty;
        }
        #endregion
    }
}
