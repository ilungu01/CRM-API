namespace CRM_API.Repository;

public interface IRepository<T>
{
    T Add(T entity);
    T GetById(int id);
    List<T> GetAll();
    T Update(int id, T entity);
    void Delete(int id);
}