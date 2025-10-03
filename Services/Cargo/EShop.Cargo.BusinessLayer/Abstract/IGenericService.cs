namespace EShop.Cargo.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TInsert(T entity);
        void TUpdate(T entity);
        void TDelete(int Id);
        T TGetById(int Id);
        List<T> TGetAll();
    }
}
