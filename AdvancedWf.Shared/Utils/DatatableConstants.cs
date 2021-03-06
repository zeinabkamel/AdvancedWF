﻿using AdvancedWf.Shared.Resources;
using AdvancedWf.Shared.ViewModels.DataTable;
 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedWf.Shared.Utils
{/// <summary>
/// 
/// </summary>
    public class DatatableConstants
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<DatatableField> CitiesDataTable = new List<DatatableField>
        {
            new DatatableField
            {
                 FieldName = Fields.Id,
                 FieldTitle = Messages.Id
            },
            new DatatableField
            {
                 FieldName = Fields.Name,
                 FieldTitle = Messages.Name
            },
        };

        /// <summary>
        /// 
        /// </summary>
        public struct Fields
        {
            public const string Id = "Id";
            public const string Name = "Name";
        }
    }
}
