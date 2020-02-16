using AdvancedWf.Shared.ViewModels.DataTable;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static AdvancedWf.Shared.Utils.Constants;

namespace AdvancedWf.Web.Controllers
{
    public class BaseController : Controller
    {
        #region Datatable Helpers
        /// <summary>
        /// Extract datatable params from the request and return it as object
        /// </summary>
        /// <returns></returns>
        protected DatatableParams GetDatatableParamsFromRequest()
        {
            return new DatatableParams
            {
                nDraw = Convert.ToInt32(HttpContext.Request.Params[DataTableParams.draw]),
                search = HttpContext.Request.Params[DataTableParams.search],
                startString = HttpContext.Request.Params[DataTableParams.start],
                endString = HttpContext.Request.Params[DataTableParams.length],
                order = HttpContext.Request.Params[DataTableParams.order],
                orderDir = HttpContext.Request.Params[DataTableParams.orderDir]
            };
        }
        #endregion

    }
}