using System.Collections.Generic;
using Exemplo.Produto.Data.TO;

namespace Exemplo.Produto.Data
{
    public interface IFornecedorDAO
    {
		IList<FornecedorTO> ObterTodos ();
		FornecedorTO Obter (int id);
		void Inserir (FornecedorTO to);
		void Atualizar (FornecedorTO to);
		void Excluir (int id);
    }
}