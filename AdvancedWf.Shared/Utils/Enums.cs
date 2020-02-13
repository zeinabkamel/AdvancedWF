using AdvancedWf.Shared.Resources;
 using System.ComponentModel.DataAnnotations;

namespace AdvancedWf.Shared.Utils
{

   

    /// <summary>
    /// Gender Enum
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Male
        /// </summary>
        [Display(Name = "Male", ResourceType = typeof(Messages))]
        Male,

        /// <summary>
        /// Female
        /// </summary>
        [Display(Name = "Female", ResourceType = typeof(Messages))]
        Female
    }

 

 

    
    /// <summary>
    ///   Status
    /// </summary>
    public enum  Status
    {
        [Display(Name = "Pending", ResourceType = typeof(Messages))]
        Pending,

        [Display(Name = "Approved", ResourceType = typeof(Messages))]
        Approved,

        [Display(Name = "Rejected", ResourceType = typeof(Messages))]
        Rejected
    }
 

    /// <summary>
    /// System User Types
    /// </summary>
    public enum UserType
    {
       

        [Display(Name = "Editor", ResourceType = typeof(Messages))]
        Editor,

        [Display(Name = "Admin", ResourceType = typeof(Messages))]
        Admin,

        [Display(Name = "Viewer", ResourceType = typeof(Messages))]
        Viewer,

       
    }

 

  
}
