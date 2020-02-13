using AdvancedWf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedWf.Data.Infrastructure
{
    /// <summary>
    ///  as  you know  that the  unit  of work  is   a singlton pattern   . 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private AdvancedWfContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public AdvancedWfContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

   

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
