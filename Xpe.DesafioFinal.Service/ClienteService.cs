using Xpe.DesafioFinal.Domain.Domain.VO;
using Xpe.DesafioFinal.Domain.Entities;
using Xpe.DesafioFinal.Domain.Interfaces;
using Xpe.DesafioFinal.Domain.VO;
using Xpe.DesafioFinal.Service.Interfaces;
using Xpe.DesafioFinal.Service.Requests;

namespace Xpe.DesafioFinal.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteBuilder _clienteBuilder;

        public ClienteService(IClienteRepository clienteRepository, IClienteBuilder clienteBuilder)
        {
            _clienteRepository = clienteRepository;
            _clienteBuilder = clienteBuilder;
        }

        public void Incluir(ClienteInclusaoRequest inclusaoClienteRequest)
        {
            Cliente cliente = MontarObjetoCliente(inclusaoClienteRequest, 0);

            VerificaDuplicacaoNome(cliente.Cpf, cliente.Id, "Já existe um cliente cadastrado com este CPF");

            _clienteRepository.Insert(cliente);
            _clienteRepository.SaveChanges();
        }

        public void Alterar(ClienteAlteracaoRequest alteracaoClienteRequest)
        {
            VerificaIdValido(alteracaoClienteRequest.Id);

            Cliente cliente = VerificaClienteExiste(alteracaoClienteRequest.Id);

            Cliente clienteAlteracao = MontarObjetoCliente(alteracaoClienteRequest, alteracaoClienteRequest.Id);

            if (cliente.Cpf != clienteAlteracao.Cpf)
                VerificaDuplicacaoNome(clienteAlteracao.Cpf, clienteAlteracao.Id, "Já existe um outro cliente cadastrado com este CPF");

            PersistirAlteracao(clienteAlteracao);
        }
               
        public void AlterarEndereco(EnderecoAlteracaoRequest alteracaoEnderecoClienteRequest)
        {
            VerificaIdValido(alteracaoEnderecoClienteRequest.Id);

            Endereco endereco = new(alteracaoEnderecoClienteRequest.Cep,
                                    alteracaoEnderecoClienteRequest.LogradouroTipo,
                                    alteracaoEnderecoClienteRequest.Logradouro,
                                    alteracaoEnderecoClienteRequest.Numero,
                                    alteracaoEnderecoClienteRequest.Complemento);

            Cliente cliente = VerificaClienteExiste(alteracaoEnderecoClienteRequest.Id);

            cliente.AlterarEndereco(endereco);

            PersistirAlteracao(cliente);
        }

        public void AlterarContatos(ContatosAlteracaoRequest alteracaoContatosClienteRequest)
        {
            VerificaIdValido(alteracaoContatosClienteRequest.Id);

            Contatos contatos = new (alteracaoContatosClienteRequest.Email,
                                     alteracaoContatosClienteRequest.Celular);

            Cliente cliente = VerificaClienteExiste(alteracaoContatosClienteRequest.Id);

            cliente.AlterarContatos(contatos);

            PersistirAlteracao(cliente);
        }

        public void Excluir(int id)
        {
            VerificaIdValido(id);
            VerificaClienteExiste(id);

            _clienteRepository.Delete(id);
            _clienteRepository.SaveChanges();
        }

        public IEnumerable<Cliente> Todos()
        {
            return _clienteRepository.GetAll();
        }

        private Cliente MontarObjetoCliente(ClienteRequest clienteRequest, int id)
        {
            _clienteBuilder.AddContatos(email: clienteRequest.Email,
                                        celular: clienteRequest.Celular);

            _clienteBuilder.AddEndereco(cep: clienteRequest.Cep,
                                        logradouroTipo: clienteRequest.LogradouroTipo,
                                        logradouro: clienteRequest.Logradouro,
                                        numero: clienteRequest.Numero,
                                        complemento: clienteRequest.Complemento);

            _clienteBuilder.AddCliente(id: id,
                                       nome: clienteRequest.Nome,
                                       cpf: clienteRequest.Cpf,
                                       dataNascimento: clienteRequest.DataNascimento);

            var cliente = _clienteBuilder.Build();
            return cliente;
        }

        private void VerificaDuplicacaoNome(string nome, int id ,string mensagem)
        {
            var cliente = BuscarPorNome(nome);

            if (cliente != null)
                if (cliente.Id != id)
                    throw new ArgumentException(mensagem);
        }

        private Cliente VerificaClienteExiste(int id)
        {
            Cliente cliente = BuscarPorId(id);

            if (cliente == null)
                throw new ArgumentException("Cliente inexistente");

            return cliente;
        }
        private static void VerificaIdValido(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id incorreto");
        }

        private void PersistirAlteracao(Cliente clienteAlteracao)
        {
            _clienteRepository.Update(clienteAlteracao, clienteAlteracao.Id);
            _clienteRepository.SaveChanges();
        }

        public Cliente BuscarPorId(int id)
            => _clienteRepository.GetById(id);  

        public Cliente? BuscarPorNome(string nome)
            => _clienteRepository.GetByNome(nome);

        public int Contar()
            =>  _clienteRepository.GetCount();
        
    }
}
