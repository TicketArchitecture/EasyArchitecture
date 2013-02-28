using System.Collections.Generic;
using Exemplo.Produto.Data;
using Exemplo.Produto.Data.TO;
using Framework.Data;
using Framework.Log;

namespace Exemplo.Produto.Business
{
    public class Produto
    {
        private static readonly IProdutoDAO dao = DAOFactory.CreateDAO<IProdutoDAO>();

        public IList<ProdutoTO> ObterTodos()
        {
            var lista = dao.ObterTodos();

            LogManager.LogReturn(lista);
            
            return lista;
        }

        public ProdutoTO Obter(int id)
        {
            LogManager.LogEntryParameters(id);

            var to = dao.Obter(id);

            LogManager.LogReturn(to);

            return to;
        }

        public ProdutoTO Inserir(ProdutoTO to)
        {
            LogManager.LogEntryParameters(to);

            dao.Inserir(to);

            LogManager.LogReturn(to);

            return to;
        }

        public void Excluir(int id)
        {
            LogManager.LogEntryParameters(id);

            dao.Excluir(id);
        }

        public ProdutoTO Atualizar(ProdutoTO to)
        {
            LogManager.LogEntryParameters(to);

            dao.Atualizar(to);

            LogManager.LogReturn(to);

            return to;
        }
    }
}

