using AdvancedWf.DTO;
using AdvancedWf.Model;
using AdvancedWf.Model.Models;
using AutoMapper;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedWf.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Category,CategoryViewModel>();
            Mapper.CreateMap<Gadget, GadgetViewModel>();

            Mapper.CreateMap<WorkflowTypes, WorkflowTypesDTO>();
        }
    }
}