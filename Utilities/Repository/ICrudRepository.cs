namespace Utilities.Repository
{
    public interface ICrudRepository
    {
        void Save<TE>(TE entity) where TE : class;
        void Delete<TE>(object id) where TE : class;
        TE? Find<TE>(object id) where TE : class;
        TE FindOrFail<TE>(object id) where TE : class;
        IList<TE> FindAll<TE>() where TE : class;
        void CommitChanges();
    }
}
