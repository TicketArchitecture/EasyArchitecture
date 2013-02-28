using System.Collections.Generic;
using Exemplo.Produto.Data;
using Exemplo.Produto.Data.TO;
using Framework.Data;
using Framework.Log;

namespace Exemplo.Produto.Business
{
    public class Categoria
    {
        private static readonly ICategoriaDAO dao = DAOFactory.CreateDAO<ICategoriaDAO>();

        public IList<CategoriaTO> ObterTodos()
        {
            var lista = dao.ObterTodos();

            LogManager.LogReturn(lista);
            
            return lista;
        }

        public CategoriaTO Obter(int id)
        {
            LogManager.LogEntryParameters(id);

            var to = dao.Obter(id);

            LogManager.LogReturn(to);

            return to;
        }

        public CategoriaTO Inserir(CategoriaTO to)
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

        public CategoriaTO Atualizar(CategoriaTO to)
        {
            LogManager.LogEntryParameters(to);

            dao.Atualizar(to);

            LogManager.LogReturn(to);

            return to;
        }
        
        
    }
}

