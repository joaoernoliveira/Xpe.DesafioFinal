using Microsoft.AspNetCore.Mvc;
using Xpe.DesafioFinal.Domain.Exceptions;

namespace Xpe.DesafioFinal.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult ExecuteServiceAction(Func<object> action, string successMessage)
        {
            var problema = new ProblemDetails
            {
                Title = "Ocorreu um erro.",
                Status = 400,
                Detail = "Ocorreu um erro interno no servidor"
            };

            try
            {
                var result = action();
                return Ok(result ?? successMessage);
            }
            catch (DomainException ex)
            {
                var validationProblem = new ValidationProblemDetails
                {
                    Title = "Erro de validação",
                    Detail = "Um ou mais erros de validação ocorreram",
                    Errors = new Dictionary<string, string[]>
                        {
                            { "Erros nas validações", ex.ErroDetalhes.ToArray() }
                        }
                };

                problema.Detail = string.Join(", ", ex.ErroDetalhes);
                return BadRequest(validationProblem);
            }
            catch (Exception ex)
            {
                problema.Detail = ex.Message;
                return BadRequest(problema);
            }
        }
    }
}
