using AdvancedWf.Data.Infrastructure;
using AdvancedWf.Model;
 
using System;
using System.Collections.Generic;
using System.Data.Entity.Repository;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedWf.Data.Repositories
{
    public class GadgetRepository : AdvancedWf.Data.Infrastructure.RepositoryBase<Gadget>, IGadgetRepository
    {
        public GadgetRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IGadgetRepository : IRepository<Gadget>
    {

    }
}
