using System.Collections.Generic;
using Exemplo.Produto.Application.Contracts.DTOs;

namespace Exemplo.Produto.Application.Contracts
{
    public interface IProdutoFacade
    {
        void Inserir(ProdutoDTO produto);
        IList<ProdutoDTO> ObterTodos();
        ProdutoDTO Obter(long id);
        void Atualizar(ProdutoDTO produto);
        void Excluir(long id);
        void InserirProdutosIguais(ProdutoDTO produto);
        IList<ProdutoDTO> ObterProdutosCadastradosAteHoje();
    }
}