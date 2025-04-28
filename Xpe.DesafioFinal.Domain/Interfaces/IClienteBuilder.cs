using Xpe.DesafioFinal.Domain.Construtores;
using Xpe.DesafioFinal.Domain.Entities;

namespace Xpe.DesafioFinal.Domain.Interfaces
{
    public interface IClienteBuilder
    {
        ClienteBuilder AddCliente(int id, string nome, string cpf, DateTime dataNascimento);
        ClienteBuilder AddContatos(string email, string celular);
        ClienteBuilder AddEndereco(string cep, string logradouroTipo, string logradouro, string numero, string complemento);
        Cliente Build();
    }
}