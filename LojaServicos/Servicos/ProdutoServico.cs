﻿using LojaRepositorios.Entidades;
using LojaRepositorios.Repositorios;

namespace LojaServicos.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        // Método construtor
        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        // CRUD
        public void Cadastrar(Produto produto)
        {

            _produtoRepositorio.Cadastrar(produto);
        }

        public List<Produto> ObterTodos(string pesquisa)
        {
            // Obter a lista de produtos da tabela de produtos
            var produtos = _produtoRepositorio.ObterTodosProdutos(pesquisa);

            // Retornar a lista de produtos
            return produtos;
        }

        public void Apagar(int id)
        {
            // Chamar o método Apagar do ProdutoRepositorio (executa o DELETE)
            _produtoRepositorio.Apagar(id);
        }

        public Produto? ObterPorId(int id)
        {
            var produto = _produtoRepositorio.ObterPorId(id);
            return produto;
        }

        public void Editar(Produto produto)
        {
            _produtoRepositorio.Editar(produto);
        }
    }
}
