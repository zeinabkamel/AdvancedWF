using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedWf.Shared.ViewModels.Common
{
    /// <summary>
    /// View model to hold the text and Value of Dropdowns
    /// </summary>
    public class DropdownViewModel
    {
        /// <summary>
        /// Record Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Record Value or Id
        /// </summary>
        public long Value { get; set; }
    }
}
