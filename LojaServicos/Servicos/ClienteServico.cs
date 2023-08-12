using LojaRepositorios.Entidades;
using LojaRepositorios.Repositorios;
using LojaServicos.Dtos.Clientes;

namespace LojaServicos.Servicos
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public void Cadastrar(ClienteCadastrarDto dto)
        {
            var cliente = ConstruirCliente(dto);

            var clienteExistenteComCpf = _clienteRepositorio.ObterPorCpf(dto.Cpf);
            if(clienteExistenteComCpf != null)
                throw new Exception($"Cliente já cadastrado com CPF: {dto.Cpf}");
            // Esse teste NÃO permite que o ClienteServiço chame o método Cadastrar do _clienteRepositorio 

            _clienteRepositorio.Cadastrar(cliente);
        }

        public List<ClienteIndexDto> ObterTodos(string pesquisa)
        {
            var clientes = _clienteRepositorio.ObterTodos(pesquisa);

            var clientesDto = ConstruirClientesDto(clientes);

            return clientesDto;
        }

        private List<ClienteIndexDto> ConstruirClientesDto(List<Cliente> clientes)
        {
            var dtos = new List<ClienteIndexDto>();

            foreach (var cliente in clientes)
            {
                var dto = new ClienteIndexDto
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Endereco = $"{cliente.Endereco.Estado} - {cliente.Endereco.Cidade}",
                    Cpf = cliente.Cpf
                };
                dtos.Add(dto);
            }
            
            return dtos;
        }

        /* Página web recebe da Aplicação por meio da ViewModel
           Aplicação recebe do Serviço por meio de um Dto
           Serviço recebe do Repositório por meio de uma Entidade(Cliente) 

           Repositório devolte as Entidades
           Serviço retorna para a aplicação as Dtos
           Aplicação devolve para a Página Web as View Models

           Página Web não pode utilizar NUNCA as entidades, deve-se seguir esse padrão */

        private Cliente ConstruirCliente(ClienteCadastrarDto dto)
        {
            return new Cliente
            {
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                DataNascimento = dto.DataNascimento,

                Endereco = new Endereco
                {
                    Estado = dto.Estado,
                    Cidade = dto.Cidade,
                    Bairro = dto.Bairro,
                    Cep = dto.Cep,
                    Logradouro = dto.Logradouro,
                    Numero = dto.Numero,
                    Complemento = dto.Complemento
                }
            };
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
