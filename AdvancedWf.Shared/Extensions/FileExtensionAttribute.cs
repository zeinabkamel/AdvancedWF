using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdvancedWf.Shared.Extensions
{
    /// <inheritdoc />
    /// <summary>
    /// File upload validate extenstion annotation
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FileExtensionAttribute : ValidationAttribute
    {

        private List<string> AllowedExtensions { get; set; }

        /// <inheritdoc />
        public FileExtensionAttribute(string fileExtensions)
        {
            AllowedExtensions = fileExtensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        /// <inheritdoc />
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;

            if (file == null) return true;
            var fileName = file.FileName.ToLower();
            var forbiddenCharcters = new[] { "<", ">", ":", "\"", "/", "\\", "|", "?", "*" };
            foreach (var c in forbiddenCharcters)
                fileName = fileName.Replace(c, "a");
            return AllowedExtensions.Any(y => fileName.EndsWith(y) );
        }
    }
}
