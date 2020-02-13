using AdvancedWf.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeHelpful.Entities.Common
{
    /// <inheritdoc />
    /// <summary>
    /// System Exception Log 
    /// </summary>
    public class ErrorLog : BaseModel
    {
        /// <summary>
        /// Error Source Method
        /// </summary>
        [Required]
        [MaxLength(100)]
        [Index]
        public virtual string Method { get; set; }

        /// <summary>
        /// Error Exception
        /// </summary>
        [Required]
        public virtual string Exception { get; set; }

        /// <summary>
        /// Exception Param if Any
        /// </summary>
        [Required(AllowEmptyStrings =true)]
        public virtual string Param { get; set; }

        /// <summary>
        /// Addtional Data if Any
        /// </summary>
        public virtual string AddtionalData { get; set; }

    }
}
