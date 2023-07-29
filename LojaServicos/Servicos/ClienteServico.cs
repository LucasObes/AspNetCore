using LojaRepositorios.Entidades;
using LojaRepositorios.Repositorios;

namespace LojaServicos.Servicos
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public void Cadastrar(Cliente cliente)
        {
            _clienteRepositorio.Cadastrar(cliente);
        }

        public List<Cliente> ObterTodos(string pesquisa)
        {
            var clientes = _clienteRepositorio.ObterTodos(pesquisa);
            return clientes;
        }

        public void Apagar(int id)
        {
            _clienteRepositorio.Apagar(id);
        }

        public Cliente? ObterPorId(int id)
        {
            var clientes = _clienteRepositorio.ObterPorId(id);
            return clientes;
        }

        public void Editar(Cliente cliente)
        {
            _clienteRepositorio.Editar(cliente);
        }
    }
}
