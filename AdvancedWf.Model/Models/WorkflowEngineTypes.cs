using AdvancedWf.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedWf.Model.Models
{
  public  class WorkflowEngineTypes:BaseModel
    {
        public virtual WorkflowTypes WorkflowTypes { set; get; }

        public virtual long WorkflowTypesId { get; set; }

        public virtual User User { set; get; }

        public virtual long UserId { get; set; }
        public long Order { get; set; }

        public Status Status { get; set; }
    }
}
