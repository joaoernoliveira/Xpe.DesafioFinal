using Xpe.DesafioFinal.Data.Config;
using Xpe.DesafioFinal.Domain.Entities;
using Xpe.DesafioFinal.Domain.Interfaces;


namespace Arquitetura.Teste.EntityDDD.Infra.Repositorios
{
    public class ClienteRepository : Repository<Cliente, int>, IClienteRepository
    {
        public ClienteRepository(SqlServerContext context) : base(context) { }

        public Cliente? GetByNome(string nome)
            =>  _dbSet.FirstOrDefault(C=>C.Nome == nome);

    }
}
