using System.Collections.Generic;
using Exemplo.Produto.Data.TO;

namespace Exemplo.Produto.Data
{
    public interface ICategoriaDAO
    {
		IList<CategoriaTO> ObterTodos ();
		CategoriaTO Obter (int id);
		void Inserir (CategoriaTO to);
		void Atualizar (CategoriaTO to);
		void Excluir (int id);
    }
}