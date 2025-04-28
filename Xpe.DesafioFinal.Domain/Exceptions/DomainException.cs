

namespace Xpe.DesafioFinal.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public List<string> ErroDetalhes { get; private set; }

        public DomainException(List<string> errosDetalhe) 
        {
            ErroDetalhes = errosDetalhe;
        }
    }
}
