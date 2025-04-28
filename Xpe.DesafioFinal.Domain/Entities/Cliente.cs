using Xpe.DesafioFinal.Domain.Domain.VO;
using Xpe.DesafioFinal.Domain.Exceptions;
using Xpe.DesafioFinal.Domain.VO;

namespace Xpe.DesafioFinal.Domain.Entities
{
    public class Cliente 
    {
        public int Id { get; private set; } = 0;
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Endereco Endereco { get; private set; }
        public Contatos Contatos { get; private set; }

        protected Cliente() { }

        public Cliente(int id, string nome, string cpf, DateTime dataNascimento, Endereco endereco, Contatos contatos)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            Contatos = contatos;
           
            Validar();
        }

        public void Alterar(Cliente cliente)
        {
            if (cliente == null)
                throw new DomainException(new List<string> { "Cliente não pode ser nulo." });

            Id = cliente.Id;
            Nome = cliente.Nome;
            Cpf = cliente.Cpf;
            DataNascimento = cliente.DataNascimento;
            Endereco = cliente.Endereco;
            Contatos = cliente.Contatos;
        }

        public void AlterarEndereco(Endereco endereco)
        {
            if (endereco == null)
                throw new DomainException( new List<string> { "Endereço não pode ser nulo." });

            Endereco = endereco;
        }
            
 
        public void AlterarContatos(Contatos contatos)
        {
            if (contatos == null)
                throw new DomainException(new List<string> { "Contatos não pode ser nulo." });

            Contatos = contatos;
        }
        private void Validar()
        {
            List<string> result = [];

            if (string.IsNullOrEmpty(Cpf) || Cpf.Length != 11)
                result.Add("[CPF] CPF tem que ter 11 caracteres");

            if (string.IsNullOrEmpty(Nome) || Nome.Length < 11 || Nome.Length > 100)
                result.Add("[Nome] Nome tem que ter entre 11 e 100 caracteres");

            if (Contatos == null)
                result.Add("Houve erro no Contato.");

            if (Endereco == null)
                result.Add("Houve erro no Endereço.");

            if (result.Count != 0)
                throw new DomainException(result);
        }
    }
}
