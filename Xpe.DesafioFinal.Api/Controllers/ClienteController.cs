using Microsoft.AspNetCore.Mvc;
using Xpe.DesafioFinal.Service.Interfaces;
using Xpe.DesafioFinal.Service.Requests;


namespace Xpe.DesafioFinal.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : BaseController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClienteInclusaoRequest inclusaoClienteRequest)
            => ExecuteServiceAction(() => { _clienteService.Incluir(inclusaoClienteRequest); return null; }, "Cliente incluído com sucesso!");

        [HttpPut]
        public IActionResult Put([FromBody] ClienteAlteracaoRequest alteracaoClienteRequest)
            => ExecuteServiceAction(() => { _clienteService.Alterar(alteracaoClienteRequest); return null; }, "Cliente alterado com sucesso!");

        [HttpPut("AlterarEndereco")]
        public IActionResult Endereco([FromBody] EnderecoAlteracaoRequest alteracaoEnderecoRequest)
            => ExecuteServiceAction(() => { _clienteService.AlterarEndereco(alteracaoEnderecoRequest); return null; }, "Endereço alterado com sucesso!");

        [HttpPut("AlterarContatos")]
        public IActionResult Contatos([FromBody] ContatosAlteracaoRequest alteracaoContatosRequest)
            => ExecuteServiceAction(() => { _clienteService.AlterarContatos(alteracaoContatosRequest); return null; }, "Contatos alterado com sucesso!");

        [HttpDelete]
        public IActionResult Delete(int Id)
            => ExecuteServiceAction(() => { _clienteService.Excluir(Id); return null; }, "Cliente Excluído com sucesso!");

        [HttpGet]
        public IActionResult Get()
            => ExecuteServiceAction(() => _clienteService.Todos(), "Nenhum cliente cadastrado!");

        [HttpGet("PorId")]
        public IActionResult PorId(int id)
            => ExecuteServiceAction(() => _clienteService.BuscarPorId(id), "Cliente Inexiste!");

        [HttpGet("PorNome")]
        public IActionResult PorNome(string nome)
            => ExecuteServiceAction(() => _clienteService.BuscarPorNome(nome), "Cliente Inexiste!");

        [HttpGet("Contar")]
        public IActionResult Contar()
            => ExecuteServiceAction(() => _clienteService.Contar(), "Nenhum cliente cadastrado!");
    }
}
