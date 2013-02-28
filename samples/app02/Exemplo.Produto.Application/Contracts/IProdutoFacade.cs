using System.Collections.Generic;
using Exemplo.Produto.Application.Contracts.DTOs;

namespace Exemplo.Produto.Application.Contracts
{
    public interface IProdutoFacade
    {
        void Inserir(ProdutoDTO produto);
        IList<ProdutoDTO> ObterTodos();
        ProdutoDTO Obter(int id);
        void Atualizar(ProdutoDTO produto);
        void Excluir(int id);
        void InserirProdutosIguais(ProdutoDTO produto);
    }
}