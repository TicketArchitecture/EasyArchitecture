using System.Collections.Generic;
using Exemplo.Produto.Data.TO;

namespace Exemplo.Produto.Data
{
    public interface IProdutoDAO
    {
		IList<ProdutoTO> ObterTodos ();
		ProdutoTO Obter (int id);
		void Inserir (ProdutoTO to);
		void Atualizar (ProdutoTO to);
		void Excluir (int id);
    }
}