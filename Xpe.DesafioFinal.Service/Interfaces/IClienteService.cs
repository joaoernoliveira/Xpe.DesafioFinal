using Xpe.DesafioFinal.Domain.Entities;
using Xpe.DesafioFinal.Service.Requests;

namespace Xpe.DesafioFinal.Service.Interfaces
{
    public interface IClienteService
    {
        void Incluir(ClienteInclusaoRequest inclusaoClienteRequest);
        void Alterar(ClienteAlteracaoRequest alteracaoClienteRequest);
        void AlterarEndereco(EnderecoAlteracaoRequest alteracaoEnderecoClienteRequest);
        void AlterarContatos(ContatosAlteracaoRequest alteracaoContatosClienteRequest);
        void Excluir(int id);
        IEnumerable<Cliente> Todos();
        Cliente BuscarPorId(int id);
        Cliente? BuscarPorNome(string nome);
        int Contar();
    }
}
