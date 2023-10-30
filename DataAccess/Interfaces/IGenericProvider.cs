namespace DataAccess.Interfaces
{
    public interface IGenericProvider<T> where T : class
    {
        void Add(T entity);
        T Get(int id);
        List<T> GetAll();
        void Remove(T entity);
    }
}