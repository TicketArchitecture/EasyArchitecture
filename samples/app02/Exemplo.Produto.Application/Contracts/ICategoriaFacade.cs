using System.Collections.Generic;
using Exemplo.Produto.Application.Contracts.DTOs;

namespace Exemplo.Produto.Application.Contracts
{
    public interface ICategoriaFacade
    {
        IList<CategoriaDTO> ObterTodos();
        CategoriaDTO Obter(int id);
        void Inserir(CategoriaDTO categoria);
        void Excluir(int id);
        void Atualizar(CategoriaDTO categoria);
    }
}