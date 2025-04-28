namespace Xpe.DesafioFinal.Service.Requests
{
    public class EnderecoAlteracaoRequest 
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string LogradouroTipo { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
    }
}
