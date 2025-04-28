namespace Xpe.DesafioFinal.Domain.Interfaces
{
    public interface IRepository<TEntity, TPK> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TPK id);
        void Update(TEntity entity, TPK Id);
        void Delete(TPK id);
        void Insert(TEntity entity);
        void SaveChanges();
        int GetCount();
    }
}
