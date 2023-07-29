using LojaRepositorios.DataBase;
using LojaRepositorios.Entidades;
using LojaRepositorios.ExtensionsMethods;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LojaRepositorios.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly LojaContexto _lojaContexto;
        private readonly DbSet<Cliente> _dbset;

        public ClienteRepositorio(LojaContexto lojaContexto)
        {
            _lojaContexto = lojaContexto;
            _dbset = _lojaContexto.Set<Cliente>();
        }

        public void Cadastrar(Cliente cliente)
        {
            _dbset.Add(cliente);
            _lojaContexto.SaveChanges();
        }

        public void Editar (Cliente cliente)
        {
            _dbset.Update(cliente);
            _lojaContexto.SaveChanges();
        }

        public void Apagar (int id)
        {
            var cliente = _dbset.FirstOrDefault(x => x.Id == id);

            if(cliente == null)
            {
                throw new Exception($"O cliente com código {id} que deseja excluir não existe");
            }

            _dbset.Remove(cliente);
            _lojaContexto.SaveChanges();
        }

        // Listagem de clientes (criar a lista com o método de ObterTodos() para todos os clientes serem listados no DataGridView utilizando o banco de dados
        public List<Cliente> ObterTodos(string? pesquisa)
        {
            var query = _dbset.AsQueryable();
            
            if(pesquisa != null && pesquisa.Trim() != "")
            {
                query = query.Where(
                x => x.Nome.Contains(pesquisa) ||
                x.Cpf.Replace("-", "").Replace(".", "") == pesquisa.ObterCpfLimpo());
			}

            return query.OrderBy(x => x.Nome).ToList();
        }

        public Cliente? ObterPorId(int id)
        {
            var cliente = _dbset.FirstOrDefault(x => x.Id == id);
            return cliente;
        }
    }
}