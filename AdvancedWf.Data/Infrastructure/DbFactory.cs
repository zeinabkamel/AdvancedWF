 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedWf.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        AdvancedWfContext dbContext;

        public AdvancedWfContext Init()
        {
            return dbContext ?? (dbContext = new AdvancedWfContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
