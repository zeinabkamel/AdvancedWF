using AdvancedWf.Shared.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedWf.DTO
{
  public  class WorkflowTypesDTO
    {
        public long Id { get; set; }
        public string ArbicName   { get; set; }

        public string EnglishName { get; set; }

        /// Record Creation Date
        /// Used for Audit
        /// </summary>
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "CreationDate", ResourceType = typeof(Messages))]
        [DataType(DataType.Date, ErrorMessageResourceName = "InvalidDate", ErrorMessageResourceType = typeof(Messages))]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Record Last Modification Date
        /// Used For Audit
        /// </summary>
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "ModificationDate", ResourceType = typeof(Messages))]
        [DataType(DataType.Date, ErrorMessageResourceName = "InvalidDate", ErrorMessageResourceType = typeof(Messages))]
        public DateTime ModificationDate { get; set; } = DateTime.Now;
    }
}
