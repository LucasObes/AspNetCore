using LojaRepositorios.Entidades;
using LojaRepositorios.Repositorios;

namespace LojaServicos.Servicos
{
    public class ClienteServico
    {
        private readonly ClienteRepositorio _clienteRepositorio;

        public ClienteServico()
        {
            _clienteRepositorio = new ClienteRepositorio();
        }

        public void Cadastrar(Cliente cliente)
        {
            _clienteRepositorio.Cadastrar(cliente);
        }

        public List<Cliente> ObterTodos()
        {
            var clientes = _clienteRepositorio.ObterTodos();
            return clientes;
        }
    }
}
