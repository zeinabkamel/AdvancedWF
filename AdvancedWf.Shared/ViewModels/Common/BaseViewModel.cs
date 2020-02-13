using System;
using System.ComponentModel.DataAnnotations;
using AdvancedWf.Shared.Resources;
 
namespace AdvancedWf.Shared.ViewModels.Common
{
    public class BaseViewModel
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Display(Name = "Id", ResourceType = typeof(Messages))]
        public virtual long Id { get; set; }

        /// <summary>
        /// Record Creation Date
        /// Used for Audit
        /// </summary>
        [Display(Name = "CreationDate", ResourceType = typeof(Messages))]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Record Last Modification Date
        /// Used For Audit
        /// </summary>
        [Display(Name = "ModificationDate", ResourceType = typeof(Messages))]

        public DateTime ModificationDate { get; set; }
    }
}
