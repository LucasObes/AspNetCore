using FluentAssertions;
using LojaRepositorios.Entidades;
using LojaRepositorios.Repositorios;
using LojaServicos.Dtos.Clientes;
using LojaServicos.Servicos;
using LojaWebTests.Builders.Entidades;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace LojaWebTest.UnitTests.LojaServicos.Servicos
{
    public class ClienteServicoTests
    {
        private readonly ClienteServico _clienteServico;
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteServicoTests()
        {
            _clienteRepositorio = Substitute.For<IClienteRepositorio>();
            _clienteServico = new ClienteServico(_clienteRepositorio);
        }

        [Fact]
        public void Test_Cadastrar_Nao_Cadastrado_Anteriorente_Sucesso()
        {
            //Arrange
            // Não passo pelo _clienteRepositório que está em ClienteServico Cadastrar()
            // Ele não chama o repositório

            var clienteCadastrarDto = new ClienteCadastrarDto
            {
                Nome = "Julio",
                Cpf = "123.456.789-10",
                DataNascimento = new DateTime(2000, 06, 20),
                Estado = "PA",
                Cidade = "Boa Vista",
                Bairro = "Bairro das Avenidas",
                Cep = "90909-90",
                Complemento = "Casa Verde",
                Logradouro = "Rua XV de Outubro",
                Numero = "200"
            };

            _clienteRepositorio.ObterPorCpf(Arg.Is("123.456.789-10")).ReturnsNull();

            // Act
            _clienteServico.Cadastrar(clienteCadastrarDto);

            // Assert
            _clienteRepositorio
                .Received(1)
                .Cadastrar(Arg.Is<Cliente>(clienteParametro => RecebeuClienteEsperado(clienteParametro)));
        }

        [Fact]
        public void Test_Cadastrar_Erro_Devido_Cliente_Cadastrado_Anteriormente()
        {
            // Arrange
            // Substitute só funciona em Interfaces

            var clienteCadastrarDto = new ClienteCadastrarDto
            {
                Nome = "Pedro",
                Cpf = "234.567.890-12"
            };

            var clienteExistente = new Cliente();
            _clienteRepositorio.ObterPorCpf(Arg.Is("234.567.890-12")).Returns(clienteExistente);

            // Act
            // () => : executando função guardando a chamada dela dentro dos parênteses, "copia" a chamada
            Action acao = () => _clienteServico.Cadastrar(clienteCadastrarDto);

            // Assert
            // FluentAssertions validação q
            var exceptionLancada = acao.Should().Throw<Exception>();
            exceptionLancada.WithMessage("Cliente já cadastrado comm CPF: 234.567.890-10");


            // XUNIT validação
            // var excecao = Assert.Throws<Exception>(acao);
            // Assert.Equal("Cliente já cadastrado comm CPF: 234.567.890-10", excecao.message);

            // clienteRepositorio não pode receber o método Cadastrar recebendo qualquer Cliente
            _clienteRepositorio.DidNotReceive().Cadastrar(Arg.Any<Cliente>());
        }

        [Fact]
        public void Test_ObterTodos_Sucesso()
        {
            // Arrange

            var clientesEsperados = new List<Cliente>
            {
                new ClienteBuilder()
                    .ComNome("Pedro")
                    .ComId(8001)
                    .ComCpf("123.456.789-10")
                    .ComEstado("SC")
                    .ComCidade("Timbó")
                    .Construir(),
                new ClienteBuilder()
                    .Construir()
            };

            _clienteRepositorio.ObterTodos(Arg.Is("")).Returns(clientesEsperados);

            // Act
            var clientes = _clienteServico.ObterTodos("");

            // Assert
            // XUnit
            // Assert.Equal(2, clientes.Count);
            // Fluent Assertion
            clientes.Should().HaveCount(2);

            clientes[0].Nome.Should().Be("Pedro");
            clientes[0].Cpf.Should().Be("123.456.789-10");
            clientes[0].Id.Should().Be(8001);
            clientes[0].Endereco.Should().Be("SC - Timbó");

            clientes[1].Nome.Should().Be("Allan de Souze");
            clientes[1].Cpf.Should().Be("123.456.123-00");
            clientes[1].Id.Should().Be(9999);
            clientes[1].Endereco.Should().Be("SC - Gaspar");

            // Forma alternativa
            /*
            Assert.Equal("Julia", clientes[1].Nome);
            Assert.Equal("234.567.890-10", clientes[1].Cpf);
            Assert.Equal(8002, clientes[1].Id);
            Assert.Equal("SC - Blumenau", clientes[1].Endereco);
            */
        }
            // Forma alternativa
            /* public bool RecebeuClienteEsperado(Cliente cliente)
            {
                Assert.Equal("Julio", cliente.Nome);
                Assert.Equal("123.456.789-10", cliente.Cpf);
                Assert.Equal(new DateTime(2000, 06, 20), cliente.DataNascimento);
                Assert.Equal("PA", cliente.Endereco.Estado);
                Assert.Equal("Boa Vista", cliente.Endereco.Cidade);
                Assert.Equal("Bairro das Avenidas", cliente.Endereco.Bairro);
                Assert.Equal("90909-90", cliente.Endereco.Cep);
                Assert.Equal("Casa Verde", cliente.Endereco.Complemento);
                Assert.Equal("Rua XV de Outubro", cliente.Endereco.Logradouro);
                Assert.Equal("200", cliente.Endereco.Numero);
                Assert.Equal(0, cliente.Id);

                return true;
            }
            */

        public bool RecebeuClienteEsperado(Cliente cliente)
        {
            cliente.Nome.Should().Be("Julio");
            cliente.Cpf.Should().Be("123.456.789-10");
            cliente.Endereco.Estado.Should().Be("PA");
            cliente.DataNascimento.Should().Be(new DateTime(2000, 06, 20));
            cliente.Endereco.Cidade.Should().Be("Boa Vista");
            cliente.Endereco.Bairro.Should().Be("Bairro das Avenidas");
            cliente.Endereco.Cep.Should().Be("90909-900");
            cliente.Endereco.Complemento.Should().Be("Casa verde");
            cliente.Endereco.Logradouro.Should().Be("Rua XY de Outubro");
            cliente.Endereco.Numero.Should().Be("200");
            cliente.Id.Should().Be(0);


            return true;
        }
    }
}
