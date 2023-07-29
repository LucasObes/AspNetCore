using LojaRepositorios.Entidades;

namespace LojaServicos.Servicos
{
    public interface IClienteServico
    {
        void Apagar(int id);
        void Cadastrar(Cliente cliente);
        void Editar(Cliente cliente);
        Cliente? ObterPorId(int id);
        List<Cliente> ObterTodos(string? pesquisa);
    }
}
