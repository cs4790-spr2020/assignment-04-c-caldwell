namespace BlabberApp.Domain.Interfaces
{
    public interface IDataStore
    {
        bool Create(IBaseEntity entity);
        IBaseEntity Read(int idx);
        bool Update(IBaseEntity entity);
        bool Delete(int idx);
    }
}
