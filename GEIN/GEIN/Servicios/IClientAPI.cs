namespace GEIN.Servicios
{
    public interface IClientAPI<T>
    {
        Task<List<T>> getAllMethod();
        Task<T> getOneByIdMethod(int id);
        Task<bool> addMethod(T t);
        Task<bool> updateMethod(int id, T t);
        Task<bool> deleteMethod(int id);
    }
}
