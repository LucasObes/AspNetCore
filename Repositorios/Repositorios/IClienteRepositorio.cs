using LojaRepositorios.Entidades;

namespace LojaRepositorios.Repositorios
{
    public interface IClienteRepositorio
    {
        void Apagar(int id);
        void Cadastrar(Cliente cliente);
        void Editar(Cliente cliente);
        Cliente? ObterPorId(int id);
        List<Cliente> ObterTodos(string? pesquisa);
        Cliente? ObterPorCpf(string cpf);
        bool ExisteComCpf(string cpf);
    }
}
