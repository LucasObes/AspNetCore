using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosLinq
{
    internal class ExemploLinqListaTiposPrimitivos
    {
        public void Executar()
        {
            var numeros = new List<int> { 2, 9, 3, 11, 15 };

            // Utilizando o LINQ, buscamos os numeros maiores que 10, gerando uma lista com eles
            var numerosMaioresDez = numeros.Where(x => x > 10).ToList();

            /* Filtrar os numeros maiores que 3 e menores que 12, gerando uma lista
               var numerosMaioresTresMenoresdoze = numeros.Where(x => x > 3).Where(x => x > 12).ToList(); */

            // Filtrar osn umeros maiores que 3 e menores que 12 utilizando somente UM where
            var numerosMaioresTresMenoresdoze = numeros.Where(x => x > 3 && x < 12).ToList();

            // Ordenar os registros em ordem crescente
            numerosMaioresTresMenoresdoze = numerosMaioresTresMenoresdoze.OrderBy(x => x).ToList();

            // Ordenar os registros em ordem decrescente
            numerosMaioresTresMenoresdoze = numerosMaioresTresMenoresdoze.OrderByDescending(x => x).ToList();

            // Adicionar elementos na lista
            numerosMaioresTresMenoresdoze.Add(11);

            var palavras = new List<string> { "Abacate", "Mamão", "Pera", "mamão" };

            // Buscar a primeira ocorrência ou default (null)
            var palavraMamao = palavras.FirstOrDefault(x => x == "Mamão");
            if (palavraMamao != null)
            {
                Console.WriteLine($"Lista de compras contém {palavraMamao.ToLower()}");
            }
            else
            {
                Console.WriteLine("PRODUTO NÃO DISPONÍVEL NO MOMENTO");
            }

            // Buscar a última ocorrência ou default (null) da palavra "Mamão" ignorando caixa alta ou não
            var palavraMamaoUltima = palavras.LastOrDefault(x => x.ToLower() == "mamão");
            Console.WriteLine(palavraMamaoUltima);

            var salarios = new List<decimal> { 1800.00m, 2300.92m, 7000.01m };

            var maiorSalario = salarios.Max(x => x);
            var menorSalario = salarios.Min(x => x);
            var mediaSalario = salarios.Average(x => x);

            Console.WriteLine(maiorSalario);
            Console.WriteLine(menorSalario);
            Console.WriteLine(mediaSalario);
        }
    }
}
