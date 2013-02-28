using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Exemplo.Produto.Data.TO;
using Framework.Data;
using Framework.Log;

namespace Exemplo.Produto.Data.Impl
{
    public class ProdutoDAO : IProdutoDAO
    {
        private const string ConnectionString = "Exemplo.Produto";

		public IList<ProdutoTO> ObterTodos ()
        {
            IList<ProdutoTO> listTO = new List<ProdutoTO>();

            const string statement = "SELECT [DataCadastro], [Descricao], [Id], [IdCategoria], [IdFornecedor], [Nome] FROM [Produto] WITH (NOLOCK) ";
            LogManager.LogSQL(statement);

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(
                ConnectionString,
                CommandType.Text, statement))
            {
                while (rdr.Read())
                {
                    listTO.Add(ExtractData(rdr));
                }
            }

            LogManager.LogReturn(listTO);
            return listTO;
        }

		public ProdutoTO Obter (int id)
        {
            LogManager.LogEntryParameters(id);

            ProdutoTO to = null;

            List<SqlParameter> parameters = new List<SqlParameter> { 
				new SqlParameter("@id",SqlDbType.Int){Value = id} 
            };
            
            const string statement = "SELECT [DataCadastro], [Descricao], [Id], [IdCategoria], [IdFornecedor], [Nome] FROM [Produto] WITH (NOLOCK) WHERE [Id] = @id ";
            LogManager.LogSQL(statement, parameters);

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(
                ConnectionString, CommandType.Text, statement, parameters.ToArray()))
                if (rdr.Read())
                {
                    to = ExtractData(rdr);
                }

            return to;
        }

		public void Inserir (ProdutoTO to)
        {
            LogManager.LogEntryParameters(to);

            List<SqlParameter> parameters = new List<SqlParameter>{
				new SqlParameter("@DataCadastro",SqlDbType.DateTime){Value = to.DataCadastro ??(object) DBNull.Value}, 
				new SqlParameter("@Descricao",SqlDbType.VarChar,50){Value = to.Descricao ??(object) DBNull.Value}, 
				new SqlParameter("@Id",SqlDbType.Int){Value = to.Id}, 
				new SqlParameter("@IdCategoria",SqlDbType.Int){Value = to.IdCategoria ??(object) DBNull.Value}, 
				new SqlParameter("@IdFornecedor",SqlDbType.Int){Value = to.IdFornecedor ??(object) DBNull.Value}, 
				new SqlParameter("@Nome",SqlDbType.VarChar,50){Value = to.Nome}
            };
            
            const string statement = "INSERT INTO [Produto] ([DataCadastro], [Descricao], [IdCategoria], [IdFornecedor], [Nome]) VALUES (@DataCadastro, @Descricao, @IdCategoria, @IdFornecedor, @Nome);SELECT SCOPE_IDENTITY()";
            LogManager.LogSQL(statement, parameters);

            var returnCode = SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, statement, parameters.ToArray());
            LogManager.LogReturn(returnCode);

            to.Id = System.Convert.ToInt32(returnCode);
        }

		public void Atualizar (ProdutoTO to)
        {
            LogManager.LogEntryParameters(to);

            List<SqlParameter> parameters = new List<SqlParameter>{ 
				new SqlParameter("@DataCadastro",SqlDbType.DateTime){Value = to.DataCadastro ??(object) DBNull.Value}, 
				new SqlParameter("@Descricao",SqlDbType.VarChar,50){Value = to.Descricao ??(object) DBNull.Value}, 
				new SqlParameter("@Id",SqlDbType.Int){Value = to.Id}, 
				new SqlParameter("@IdCategoria",SqlDbType.Int){Value = to.IdCategoria ??(object) DBNull.Value}, 
				new SqlParameter("@IdFornecedor",SqlDbType.Int){Value = to.IdFornecedor ??(object) DBNull.Value}, 
				new SqlParameter("@Nome",SqlDbType.VarChar,50){Value = to.Nome} 
            };

            const string statement = "UPDATE [Produto] SET [DataCadastro] = @DataCadastro, [Descricao] = @Descricao, [IdCategoria] = @IdCategoria, [IdFornecedor] = @IdFornecedor, [Nome] = @Nome WHERE [Id] = @Id ";
            LogManager.LogSQL(statement, parameters);

            var afectedRows = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, statement, parameters.ToArray());
            LogManager.LogReturn(afectedRows);

        }

		public void Excluir (int id)
        {
            LogManager.LogEntryParameters(id);

            List<SqlParameter> parameters = new List<SqlParameter> { 
				new SqlParameter("@id",SqlDbType.Int){Value = id} 
            };

            const string statement = "DELETE FROM [Produto] WHERE [Id] = @id ";
            LogManager.LogSQL(statement, parameters);

            var afectedRows = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, statement, parameters.ToArray());
            LogManager.LogReturn(afectedRows);
        }        



        private static ProdutoTO ExtractData(IDataRecord rdr)
        {
            return new ProdutoTO
            {
				DataCadastro =  rdr.IsDBNull(0)? null :(DateTime?)rdr.GetDateTime(0), 
				Descricao =  rdr.IsDBNull(1)? null :(string)rdr.GetString(1), 
				Id = rdr.GetInt32(2), 
				IdCategoria =  rdr.IsDBNull(3)? null :(int?)rdr.GetInt32(3), 
				IdFornecedor =  rdr.IsDBNull(4)? null :(int?)rdr.GetInt32(4), 
				Nome = rdr.GetString(5)
            };
        }

    }
}