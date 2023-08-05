using LojaRepositorios.Entidades;
using LojaServicos.Dtos.Clientes;

namespace LojaServicos.Servicos
{
    public interface IClienteServico
    {
        void Apagar(int id);
        void Cadastrar(ClienteCadastrarDto cliente);
        void Editar(Cliente cliente);
        Cliente? ObterPorId(int id);
        List<ClienteIndexDto> ObterTodos(string? pesquisa);
    }
}
