using System.Collections.Generic;
using Exemplo.Produto.Application.Contracts.DTOs;

namespace Exemplo.Produto.Application.Contracts
{
    public interface IFornecedorFacade
    {
        IList<FornecedorDTO> ObterTodos();
        FornecedorDTO Obter(int id);
        void Inserir(FornecedorDTO fornecedor);
        void Excluir(int id);
        void Atualizar(FornecedorDTO fornecedor);
    }
}