using Xpe.DesafioFinal.Domain.Domain.VO;
using Xpe.DesafioFinal.Domain.Entities;
using Xpe.DesafioFinal.Domain.Exceptions;
using Xpe.DesafioFinal.Domain.Interfaces;
using Xpe.DesafioFinal.Domain.VO;

namespace Xpe.DesafioFinal.Domain.Construtores
{
    public class ClienteBuilder : IClienteBuilder
    {
        private Cliente _cliente;
        private Endereco _endereco;
        private Contatos _contatos;

        private readonly List<string> _erros = new();

        public ClienteBuilder AddContatos(string email, string celular)
        {
            try
            {
                _contatos = new Contatos(email, celular);
            }
            catch (DomainException ex)
            {
                _erros.AddRange(ex.ErroDetalhes);
            }

            return this;
        }

        public ClienteBuilder AddEndereco(string cep, string logradouroTipo, string logradouro, string numero, string complemento)
        {
            try
            {
                _endereco = new Endereco(cep, logradouroTipo, logradouro, numero, complemento);
            }
            catch (DomainException ex)
            {
                _erros.AddRange(ex.ErroDetalhes);
            }

            return this;
        }

        public ClienteBuilder AddCliente(int id, string nome, string cpf, DateTime dataNascimento)
        {
            try
            {
                _cliente = new Cliente(id, nome, cpf, dataNascimento, _endereco, _contatos);
            }
            catch (DomainException ex)
            {
                _erros.AddRange(ex.ErroDetalhes);
            }

            return this;
        }

        public Cliente Build()
        {
            if (_erros.Count == 0)
            {
                if (_cliente == null)
                    _erros.Add("Erro ao criar cliente");
                if (_contatos == null)
                    _erros.Add("Erro ao criar contatos");
                if (_endereco == null)
                    _erros.Add("Erro ao criar endereço");
            }
            
            if (_erros.Count == 0)
                return _cliente;

            throw new DomainException(_erros);
        }
    }
}

