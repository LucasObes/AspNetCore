using Microsoft.AspNetCore.Mvc;
using LojaServicos.Servicos;
using LojaRepositorios.Entidades;

namespace LojaWeb.Controllers
{
    [Route("/cliente")]

    public class ClienteController : Controller
    {
        private readonly IClienteServico _clienteServico;

        public ClienteController(IClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] string? pesquisa) // cliente?pesquisa=OQUEQUEROPESQUISAR
        {
            var clientes = _clienteServico.ObterTodos(pesquisa);
            ViewBag.Clientes = clientes;
            ViewBag.Pesquisa = pesquisa;

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
            [FromForm] string cep,
            [FromForm] string bairro,
            [FromForm] string logradouro,
            [FromForm] string numero,
            [FromForm] string? complemento
            )
        {

            var cliente = new Cliente();
            cliente.Nome = nome;
            cliente.Cpf = cpf;
            cliente.DataNascimento = dataNascimento;

            cliente.Endereco = new Endereco();
            cliente.Endereco.Cidade = cidade;
            cliente.Endereco.Estado = estado;
            cliente.Endereco.Cep = cep;
            cliente.Endereco.Bairro = bairro;
            cliente.Endereco.Logradouro = logradouro;
            cliente.Endereco.Numero = numero;
            cliente.Endereco.Complemento = complemento;


            _clienteServico.Cadastrar(cliente);

            return RedirectToAction("Index");
        }
    }
}
