using Microsoft.AspNetCore.Mvc;
using LojaServicos.Servicos;
using LojaRepositorios.Entidades;

namespace LojaWeb.Controllers
{
    [Route("/cliente")]

    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var clienteServico = new ClienteServico();
            var clientes = clienteServico.ObterTodos();
            ViewBag.Clientes = clientes;

            return View();
        }

        [Route("cadastrar")]
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar(
            [FromForm] string nome,
            [FromForm] string cpf,
            [FromForm] DateTime dataNascimento,
            [FromForm] string cidade,
            [FromForm] string estado,
            [FromForm] string cep
            )
        {
            var clienteServico = new ClienteServico();

            var cliente = new Cliente();
            cliente.Nome = nome;
            cliente.Cpf = cpf;
            cliente.DataNascimento = dataNascimento;
            cliente.Endereco.Cidade = cidade;
            cliente.Endereco.Estado = estado;
            cliente.Endereco.Cep = cep;

            clienteServico.Cadastrar(cliente);

            return RedirectToAction("Index");
        }
    }
}
