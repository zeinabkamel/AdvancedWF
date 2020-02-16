using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedWf.Data.Infrastructure
{
    public   class RepositoryBase<T> where T : class
    {
        #region Properties
        private AdvancedWfContext dataContext;
        private AdvancedWfContext dbContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected AdvancedWfContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        #endregion

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        public RepositoryBase(AdvancedWfContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region Implementation
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        #endregion

        #region Data table
        /// <summary>
        /// get data table items count based on viewModel EndString property
        /// </summary>
        /// <param name="endString">Page Length</param>
        /// <returns>items count</returns>
        public static int GetLength(string endString)
        {
            var length = 10;
            var d = !string.IsNullOrEmpty(endString) && int.TryParse(endString, out length);
            if (length <= 0)
            {
                length = 10;
            }

            return length;
        }
        /// <summary>
        /// get data table start index based on StartString
        /// </summary>
        /// <param name="startString">Start page of dataTable</param>
        /// <returns>start index</returns>
        public static int GetStart(string startString)
        {
            int start = 0;
            var d = !string.IsNullOrEmpty(startString) && int.TryParse(startString, out start);
            if (start < 0)
            {
                start = 0;
            }

            return start;
        }
        #endregion
    }
}
