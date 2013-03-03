using System;
using Exemplo.Produto.Domain.Entities;
using Exemplo.Produto.Domain.Repositories;

namespace Exemplo.Produto.Tests.Helpers
{
    public static class DataBaseHelper
    {
        public static void LoadData(ICategoriaRepository categoriaRepository, IFornecedorRepository fornecedorRepository, IProdutoRepository produtoRepository)
        {
            var categoria = new Categoria { Id = 1, Descricao = "Aves" };
            var fornecedor = new Fornecedor { Id = 1, Nome = "Astrogildo", Telefone = "1111-2222", DataCadastro = new DateTime(2010, 01, 01) };

            categoriaRepository.Save(categoria);
            fornecedorRepository.Save(fornecedor);

            produtoRepository.Save(new Domain.Entities.Produto()
            {
                Nome = "Tenis Kichute",
                Descricao = "O Tenis mais estranho ja fabricado",
                DataCadastro = DateTime.Now,
                Categoria = categoria,
                Fornecedor = fornecedor
            });
            produtoRepository.Save(new Domain.Entities.Produto()
            {
                Nome = "Canario Belga",
                DataCadastro = DateTime.Now,
                Categoria = categoria,
                Fornecedor = fornecedor
            });
            produtoRepository.Save(new Domain.Entities.Produto()
            {
                Nome = "Caixa Bombom",
                DataCadastro = DateTime.Now,
                Categoria = categoria,
                Fornecedor = fornecedor
            });
            produtoRepository.Save(new Domain.Entities.Produto()
            {
                Nome = "Lagarto",
                DataCadastro = DateTime.Now,
                Categoria = categoria,
                Fornecedor = fornecedor
            });
            produtoRepository.Save(new Domain.Entities.Produto()
            {
                Nome = "Crocodilo",
                DataCadastro = DateTime.Now,
                Categoria = categoria,
                Fornecedor = fornecedor
            });
            produtoRepository.Save(new Domain.Entities.Produto()
            {
                Nome = "Tenis Conga",
                DataCadastro = DateTime.Now,
                Categoria = categoria,
                Fornecedor = fornecedor
            });
            produtoRepository.Save(new Domain.Entities.Produto()
            {
                Nome = "Teste",
                Descricao = "O Tenis mais estranho ja fabricado",
                DataCadastro = DateTime.Now,
                Categoria = categoria,
                Fornecedor = fornecedor
            });
            produtoRepository.Save(new Domain.Entities.Produto()
            {
                Nome = "Outro",
                Descricao = "Outro",
                DataCadastro = DateTime.Now,
                Categoria = categoria,
                Fornecedor = fornecedor
            });
        }
    }
}
