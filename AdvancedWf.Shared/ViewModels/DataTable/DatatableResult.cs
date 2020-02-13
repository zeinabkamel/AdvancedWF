using System.Collections.Generic;

namespace AdvancedWf.Shared.ViewModels
{
    /// <summary>
    /// View model to hold the dataTable response data
    /// </summary>
    public class DatatableResult
    {
        /// <summary>
        /// Draw counter.
        /// This is used by DataTables to ensure that the Ajax returns from server-side processing requests are drawn in sequence by DataTables (Ajax requests are asynchronous and thus can return out of sequence).
        /// This is used as part of the draw return parameter (see below).
        /// </summary>
        public int draw;

        /// <summary>
        /// Total Records count
        /// </summary>
        public int recordsTotal;
        /// <summary>
        /// Filtered records count
        /// </summary>
        public int recordsFiltered;

        /// <summary>
        /// Table Data
        /// </summary>
        public List<object> data = new List<object>();

        /// <summary>
        /// Error Message
        /// </summary>
        public string error { get; set; }
    }
}
