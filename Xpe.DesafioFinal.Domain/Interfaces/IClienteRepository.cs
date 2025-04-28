using Xpe.DesafioFinal.Domain.Entities;

namespace Xpe.DesafioFinal.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente, int>
    {
        Cliente? GetByNome(string nome);
    }
}
