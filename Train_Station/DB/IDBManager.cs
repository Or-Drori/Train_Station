
namespace Train_Station.DB
{
    public interface IDBManager<T> where T : IDatabaseEntity
    {
        List<T> DBList { get; set; }

        void Create(T entity);
        T? GetById(int id);
        void Update(T entity);
    }
}