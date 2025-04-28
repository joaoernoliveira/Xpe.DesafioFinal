using System.Text.RegularExpressions;
using Xpe.DesafioFinal.Domain.Exceptions;

namespace Xpe.DesafioFinal.Domain.Domain.VO
{
    public class Contatos
    {
        protected Contatos() { }
        public string Email { get; private set; }
        public string Celular {  get; private set; }

        public Contatos(string email, string celular)
        {
            Email = email;
            Celular = celular;

            Validar();
        }

        private void Validar()
        {
            var listErros = new List<string>();
           
            if (Celular == null)
                listErros.Add("[Celular] Celular não pode ser nulo");

            if (string.IsNullOrEmpty(Email) || ! Regex.Match(Email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").Success)
                listErros.Add("[Email] Email inválido");
            
            if (listErros.Count > 0) 
                throw new DomainException(listErros);
        }
    }
}
