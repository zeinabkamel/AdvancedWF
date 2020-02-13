namespace AdvancedWf.Shared.ViewModels.DataTable
{
    /// <summary>
    /// class to hold the dataTable parameters to make operation on its values
    /// </summary>
    public class DatatableParams
    {
        /// <summary>
        /// Global search value. To be applied to all columns which have searchable as true.
        /// </summary>
        public string search { get; set; }
        /// <summary>
        /// The start page number
        /// </summary>
        public string startString { get; set; }
        /// <summary>
        /// The page legnth
        /// </summary>
        public string endString { get; set; }
        /// <summary>
        /// the column to be ordered.
        /// </summary>
        public string order { get; set; }
        /// <summary>
        /// Ordering direction for this column.
        /// It will be dt-string asc or dt-string desc to indicate ascending ordering or descending ordering, respectively.
        /// </summary>
        public string orderDir { get; set; }
        /// <summary>
        /// Draw counter.
        /// This is used by DataTables to ensure that the Ajax returns from server-side processing requests are drawn in sequence by DataTables (Ajax requests are asynchronous and thus can return out of sequence).
        /// This is used as part of the draw return parameter (see below).
        /// </summary>
        public int nDraw { get; set; }


    }
}
