using Microsoft.EntityFrameworkCore;
using Xpe.DesafioFinal.Domain.Interfaces;


namespace Arquitetura.Teste.EntityDDD.Infra.Repositorios
{   
    public class Repository<TEntity, TPK> : IRepository<TEntity, TPK> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

       public IEnumerable<TEntity> GetAll()
            => _dbSet.ToList();

        public int GetCount()
            => _dbSet.Count();

        public TEntity? GetById(TPK id)
            => _dbSet.Find(id);

        public void Update(TEntity entity, TPK Id)
        {
            var result = _dbSet.Find(Id);
            if (result != null)
                _context.Entry(result).CurrentValues.SetValues(entity);
        }

        public virtual void Delete(TPK id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public virtual void Insert(TEntity entity)
            => _dbSet.Add(entity);

        public virtual void SaveChanges()
            => _context.SaveChanges();
    }
    
}