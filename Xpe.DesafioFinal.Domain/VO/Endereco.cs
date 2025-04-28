using Xpe.DesafioFinal.Domain.Exceptions;

namespace Xpe.DesafioFinal.Domain.VO
{
    public class Endereco 
    {
        protected Endereco() { }
        public string Cep { get; private set; }
        public string LogradouroTipo { get; private set; }
        public string Logradouro {  get; private set; }
        public string Numero {  get; private set; }
        public string Complemento { get; private set; }

        public Endereco(string cep, string logradouroTipo, string logradouro, string numero, string complemento)
        {
            Cep = cep;
            LogradouroTipo = logradouroTipo;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;

            Validar();
        }

        public void Validar()
        {
            List<string> result = new List<string>();

            if (Cep.Length != 8)
                result.Add("[Cep] CEP tem que ter 8 dígitos");

            if (LogradouroTipo == null || LogradouroTipo.Length < 3 || LogradouroTipo.Length > 30)
                result.Add("[LogradouroTipo] Tipo de Logradouro tem que ter no mínimo 3 caracteres e no máximo 30");

            if (Logradouro == null || Logradouro.Length < 3 || Logradouro.Length > 50)
                result.Add("[Logradouro] Logradouro tem que ter no mínimo 3 caracteres e no máximo 30");

            if (result.Count != 0)
                throw new DomainException(result);
        }
    }
}
