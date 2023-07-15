using LojaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ExemploCampos()
        {
            return View();
        }

        public IActionResult CadastroPersonagem()
        {
            return View();
        }

        public IActionResult CadastrarPersonagem([FromQuery] string nome, [FromQuery] int idade)
        {
            var anohoje = DateTime.Now.Year;
            var anoNascimento = anohoje - idade;
            var status = "";
            if (idade < 18)
            {
                status = "Menor de 18 anos";
            }
            else
            {
                status = "Maior ou igual a 18 anos";
            }

            var mensagem = $"{nome} nasceu em {anoNascimento}. Status: {status}";

            return Ok(mensagem);
        }

        public IActionResult CadastroNome()
        {
            return View();
        }

        public IActionResult NomeCompleto([FromQuery] string nome, [FromQuery] string sobrenome)
        {
            var mensagem = $"O seu nome completo é: {nome} {sobrenome}";

            return Ok(mensagem);
        }

        public IActionResult DadosImc()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalcularImc([FromForm] string nome, [FromForm] double altura, [FromForm] double peso)
        {
            var calculoImc = peso / Math.Pow(altura, 2);

            var mensagem = $"Olá {nome}, o seu IMC é de {calculoImc}";
            return Ok(mensagem);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}