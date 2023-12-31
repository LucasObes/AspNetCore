﻿using LojaRepositorios.Entidades;
using LojaServicos.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace LojaAPI.Controllers
{
    [Route("produtos")]
    public class ProdutoController : Controller
    {
        private IProdutoServico _produtoServico;

        public ProdutoController(IProdutoServico produtoServico)
        {
            _produtoServico = produtoServico;
        }

        [HttpGet]
        // GetAll: tipo o ObterTodos
        public IActionResult GetAll()
        {
            var produtos = _produtoServico.ObterTodos(string.Empty);

            return Ok(produtos);
        }

        // Obter por Id/detalhe
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _produtoServico.ObterPorId(id);

            return Ok(produto);
        }

        // Cadastrar um produto
        // /produtos
        [HttpPost]
        public IActionResult Create([FromBody] ProdutoCreateModel produtoCreateModel)
        {
            var produto = new Produto
            {
                Nome = produtoCreateModel.Nome.Trim(),
                PrecoUnitario = produtoCreateModel.PrecoUnitario,
                Quantidade = produtoCreateModel.Quantidade
            };

            return Ok();
        }

        // /produtos/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _produtoServico.Apagar(id);

            return Ok();
        }

        // Alterar os dados de um produto
        // /produtos/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProdutoUpdateModel produtoUpdateModel)
        {
            var produto = new Produto
            {
                Id = id,
                Nome = produtoUpdateModel.Nome.Trim(),
                PrecoUnitario = produtoUpdateModel.PrecoUnitario,
                Quantidade = produtoUpdateModel.Quantidade
            };

            _produtoServico.Editar(produto);

            return Ok();
        }
    }

    public class ProdutoUpdateModel
    {
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }

    public class ProdutoCreateModel
    {
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
