namespace PostDemoApi.Contracts {
    public interface IGenericRepository<T> where T : class {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);

    }
}
