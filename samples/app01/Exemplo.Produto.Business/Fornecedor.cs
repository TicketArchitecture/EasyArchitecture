using System.Collections.Generic;
using Exemplo.Produto.Data;
using Exemplo.Produto.Data.TO;
using Framework.Data;
using Framework.Log;

namespace Exemplo.Produto.Business
{
    public class Fornecedor
    {
        private static readonly IFornecedorDAO dao = DAOFactory.CreateDAO<IFornecedorDAO>();

        public IList<FornecedorTO> ObterTodos()
        {
            var lista = dao.ObterTodos();

            LogManager.LogReturn(lista);
            
            return lista;
        }

        public FornecedorTO Obter(int id)
        {
            LogManager.LogEntryParameters(id);

            var to = dao.Obter(id);

            LogManager.LogReturn(to);

            return to;
        }

        public FornecedorTO Inserir(FornecedorTO to)
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

        public FornecedorTO Atualizar(FornecedorTO to)
        {
            LogManager.LogEntryParameters(to);

            dao.Atualizar(to);

            LogManager.LogReturn(to);

            return to;
        }
        
        
    }
}

