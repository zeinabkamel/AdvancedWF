using AdvancedWf.Shared.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace AdvancedWf.Model
{
    /// <summary>
    /// Parent Entity for all System Entities
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        [Display(Name = "Id", ResourceType = typeof(Messages))]
        public   long Id { get; set; }

        /// <summary>
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
