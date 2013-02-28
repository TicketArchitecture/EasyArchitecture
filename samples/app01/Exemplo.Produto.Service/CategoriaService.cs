using System;
using System.Collections.Generic;
using Exemplo.Produto.Business;
using Exemplo.Produto.Data.TO;
using Framework.Log;
using Framework;
using Framework.Service;

namespace Exemplo.Produto.Service
{
    public class CategoriaService
    {
        private static readonly Categoria business = new Categoria();

        public IList<CategoriaTO> ObterTodos()
        {
            var lista = business.ObterTodos();

            LogManager.LogReturn(lista);

            return lista;
        }

        public CategoriaTO Obter(int id)
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


        public CategoriaTO Inserir(CategoriaTO to)
        {
            LogManager.LogEntryParameters(to);

            try
            {
                Check.Require(!string.IsNullOrEmpty(to.Descricao), ResourceWrapper.GetMessage("MSG0001"));

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


        public CategoriaTO Atualizar(CategoriaTO to)
        {
            LogManager.LogEntryParameters(to);

            try
            {
                Check.Require(!string.IsNullOrEmpty(to.Descricao), ResourceWrapper.GetMessage("MSG0001"));

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