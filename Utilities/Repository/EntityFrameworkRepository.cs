using Microsoft.EntityFrameworkCore;
using Utilities.Exceptions;

namespace Utilities.Repository
{
    public abstract class EntityFrameworkRepository<T> : ICrudRepository where T : DbContext
    {
        protected T dbContext;

        protected EntityFrameworkRepository(T dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Save<TE>(TE entity) where TE : class
        {
            dbContext.Add(entity);
        }

        public IList<TE> FindAll<TE>() where TE : class
        {
            return dbContext.Set<TE>().ToList();
        }

        public TE? Find<TE>(object id) where TE : class
        {
            return dbContext.Find<TE>(id);
        }

        public TE FindOrFail<TE>(object id) where TE : class
        {
            return dbContext.Find<TE>(id) ?? throw new CustomException($"The {typeof(TE).Name} doesn´t exist");
        }

        public void Delete<TE>(object identity) where TE : class
        {
            var found = FindOrFail<TE>(identity);
            dbContext.Remove(found);
        }

        public void CommitChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
