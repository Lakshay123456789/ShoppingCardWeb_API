namespace BusinessLayer.Resportiory
{
    public interface IGenericRepository<T>
    {
         Task<bool> Delete(object id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        void Insert(T obj);
        void Save();
        Task<T> Update(T obj);
//        List<T> productName(string name);
    }
}