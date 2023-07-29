using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosLinq
{
    internal class ExemploLinqListaObjetos
    {
        public void Executar()
        {
            var animes = new List<Anime>();
            var assassinationClassroom = new Anime()
            {
                Id = 1,
                Nome = "Assassination Classroom",
                Categoria = "Comédia",
                QuantidadeTemporadas = 2
            };
            var bleach = new Anime()
            {
                Id = 2,
                Nome = "Bleach",
                Categoria = "Shounen",
                QuantidadeTemporadas = 14
            };
            var kurokosBasketball = new Anime()
            {
                Id = 3,
                Nome = "Kuroko's no Basket",
                Categoria = "Esportes",
                QuantidadeTemporadas = 4
            };
            var naruto = new Anime()
            {
                Id = 4,
                Nome = "Naruto",
                Categoria = "Shounen",
                QuantidadeTemporadas = 9
            };
            var blackClover = new Anime()
            {
                Id = 5,
                Nome = "Black Clover",
                Categoria = "Shounen",
                QuantidadeTemporadas = 1
            };
            animes.Add(assassinationClassroom);
            animes.Add(bleach);
            animes.Add(kurokosBasketball);
            animes.Add(naruto);
            animes.Add(blackClover);

            // Traz a lista de animes organizada por categoria e por nome em orden alfabética
            var animesOrdenados = animes.OrderBy(x => x.Categoria).ThenBy(x => x.Nome).ToList();
            ApresentarAnimes(animesOrdenados);

            // Apresentar o número total de cadastros com o que eu selecionar
            var animesShounenQuantidade = animes.Where(x => x.Categoria == "Shounen").Count();
            Console.WriteLine($"----------------------------ANIMES SHOUNEN({animesShounenQuantidade})----------------------------");
            var animesShounen = animes.Where(x => x.Categoria == "Shounen").OrderBy(x => x.Nome).ToList();
            ApresentarAnimes(animesShounen);
        }

        public void ApresentarAnimes(List<Anime> animes)
        {
            foreach(var anime in animes)
            {
                Console.WriteLine($"Id: {anime.Id}");
                Console.WriteLine($"Nome: {anime.Nome}");
                Console.WriteLine($"Categoria: {anime.Categoria}");
                Console.WriteLine($"Quantidade de temporadas: {anime.QuantidadeTemporadas}");
                Console.WriteLine("\n");
            }
        }

        public class Anime
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public int QuantidadeTemporadas { get; set; }
            public string Categoria { get; set; }
        }
    }
}
