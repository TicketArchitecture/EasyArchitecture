using System;
using System.Collections.Generic;
using System.Transactions;
using Exemplo.Produto.Data.TO;
using Framework.Log;
using Framework;
using Framework.Service;

namespace Exemplo.Produto.Service
{
    public class ProdutoService
    {
        private static readonly Business.Produto business = new Business.Produto();

        public IList<ProdutoTO> ObterTodos()
        {
            var lista = business.ObterTodos();

            LogManager.LogReturn(lista);

            return lista;
        }

        public ProdutoTO Obter(int id)
        {
            LogManager.LogEntryParameters(id);

            try
            {
                var to = business.Obter(id);

                LogManager.LogReturn(to);

                return to;
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
                throw;
            }
        }


        public ProdutoTO Inserir(ProdutoTO to)
        {
            LogManager.LogEntryParameters(to);

            try
            {
                Check.Require(!string.IsNullOrEmpty(to.Nome), ResourceWrapper.GetMessage("MSG0001"));

                business.Inserir(to);

                LogManager.LogReturn(to);

                return to;
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
                throw;
            }
        }

        public ProdutoTO InserirProdutosIguais(ProdutoTO to)
        {
            LogManager.LogEntryParameters(to);

            try
            {
                Check.Require(!string.IsNullOrEmpty(to.Nome), ResourceWrapper.GetMessage("MSG0001"));

                using (TransactionScope transactionScope = new TransactionScope())
                {
                    business.Inserir(to);
                    business.Inserir(to);
                    business.Inserir(to);

                    transactionScope.Complete();
                }

                LogManager.LogReturn(to);

                return to;
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
                throw;
            }
        }


        public void Excluir(int id)
        {
            LogManager.LogEntryParameters(id);

            try
            {
                business.Excluir(id);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
                throw;
            }
        }


        public ProdutoTO Atualizar(ProdutoTO to)
        {
            LogManager.LogEntryParameters(to);

            try
            {
                Check.Require(!string.IsNullOrEmpty(to.Nome), ResourceWrapper.GetMessage("MSG0001"));

                business.Atualizar(to);

                LogManager.LogReturn(to);

                return to;
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
                throw;
            }
        }
    }
}