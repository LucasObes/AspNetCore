﻿using LojaRepositorios.DataBase;
using LojaRepositorios.Entidades;
using System.Data;

namespace LojaRepositorios.Repositorios
{
    public class ClienteRepositorio
    {
        private readonly BancoDadosConexao _bancoDadosConexao;

        public ClienteRepositorio()
        {
            _bancoDadosConexao = new BancoDadosConexao();
        }

        public void Cadastrar(Cliente cliente)
        {
            var comando = _bancoDadosConexao.Conectar();

            comando.CommandText = @"INSERT INTO clientes 
                (nome,  cpf,  data_nascimento,  estado,  cidade,  bairro,  cep,  
                logradouro,  numero,  complemento)
            VALUES 
                (@NOME, @CPF, @DATA_NASCIMENTO, @ESTADO, @CIDADE, @BAIRRO, @CEP, 
                @LOGRADOURO, @NUMERO, @COMPLEMENTO)";

            comando.Parameters.AddWithValue("@NOME", cliente.Nome);
            comando.Parameters.AddWithValue("@CPF", cliente.Cpf);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.DataNascimento);
            comando.Parameters.AddWithValue("@ESTADO", cliente.Endereco.Estado);
            comando.Parameters.AddWithValue("@CIDADE", cliente.Endereco.Cidade);
            comando.Parameters.AddWithValue("@BAIRRO", cliente.Endereco.Bairro);
            comando.Parameters.AddWithValue("@CEP", cliente.Endereco.Cep);
            comando.Parameters.AddWithValue("@LOGRADOURO", cliente.Endereco.Logradouro);
            comando.Parameters.AddWithValue("@NUMERO", cliente.Endereco.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", cliente.Endereco.Complemento);

            comando.ExecuteNonQuery();
        }

        // Listagem de clientes (criar a lista com o método de ObterTodos() para todos os clientes serem listados no DataGridView utilizando o banco de dados
        public List<Cliente> ObterTodos()
        {
            var bancoDadosConexao = new BancoDadosConexao();
            var comando = bancoDadosConexao.Conectar();
            comando.CommandText = "SELECT * FROM clientes";

            var tabelaEmMemoria = new DataTable();
            tabelaEmMemoria.Load(comando.ExecuteReader());

            var clientes = new List<Cliente>();

            /*
            for (var i = 0; i < tabelaEmMemoria.Rows.Count; i++)
            {
                // obter da lista de registros um registro em determinada posição (iterando a lista)
                var registro = tabelaEmMemoria.Rows[i];
            }
            */

            foreach (DataRow registro in tabelaEmMemoria.Rows)
            {
                var cliente = new Cliente();
                cliente.Nome = registro["nome"].ToString();
                cliente.Id = Convert.ToInt32(registro["id"]);
                cliente.Cpf = registro["cpf"].ToString();
                cliente.DataNascimento = Convert.ToDateTime(registro["data_nascimento"]);

                cliente.Endereco = new Endereco();
                cliente.Endereco.Cep = registro["cep"].ToString();
                cliente.Endereco.Numero = registro["numero"].ToString();
                cliente.Endereco.Estado = registro["estado"].ToString();
                cliente.Endereco.Cidade = registro["cidade"].ToString();
                cliente.Endereco.Bairro = registro["bairro"].ToString();
                cliente.Endereco.Logradouro = registro["logradouro"].ToString();
                cliente.Endereco.Complemento = registro["complemento"].ToString();

                clientes.Add(cliente);
            }
            return clientes;
        }
    }
}