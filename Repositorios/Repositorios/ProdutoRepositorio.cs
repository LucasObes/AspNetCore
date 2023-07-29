using LojaRepositorios.DataBase;
using LojaRepositorios.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LojaRepositorios.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly LojaContexto _lojaContexto;
        private readonly DbSet<Produto> _dbset;

        // Método construtor: executado quando ocorre um new da classe, ou seja um "new ProdutoRepositorio()", irá executar o construtor
        public ProdutoRepositorio(LojaContexto lojaContexto)
        {
            _lojaContexto = lojaContexto;
            _dbset = _lojaContexto.Set<Produto>();
        }

        // CRUD
        public void Cadastrar(Produto produto)
        {
            _dbset.Add(produto);
            _lojaContexto.SaveChanges();
        }

        public void Editar(Produto produto)
        {
            _dbset.Update(produto);
            _lojaContexto.SaveChanges();
        }

        public void Apagar(int id)
        {
            var produto = _dbset.FirstOrDefault(x => x.Id == id);

            if (produto == null)
            {
                throw new Exception($"Produto com código {id} não existe");
            }

            _lojaContexto.Set<Produto>().Remove(produto);
            _lojaContexto.SaveChanges();
        }

        public List<Produto> ObterTodosProdutos(string pesquisa)
        {
            return _dbset.Where(x => x.Nome.Contains(pesquisa)).OrderBy(x => x.Nome).ToList();
        }

        public Produto? ObterPorId(int id)
        {
            var produto = _dbset.FirstOrDefault(x => x.Id == id);
            return produto;
        }
    }
}
