using AdvancedWf.Shared.Resources;
using AdvancedWf.Shared.Utils;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdvancedWf.Model.Models
{
   public class User: IdentityUser
    {
     
        /// <summary>
        /// User's Display Name
        /// </summary>
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLengthField", ErrorMessageResourceType = typeof(Messages))]
        [MinLength(3, ErrorMessageResourceName = "MinLengthField", ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "DisplayName", ResourceType = typeof(Messages))]
        public virtual string DisplayName { get; set; }


        /// <summary>
        /// User's Type
        /// </summary>
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Index]
        [Display(Name = "Type", ResourceType = typeof(Messages))]
        public virtual UserType Type { get; set; }
    }
}
