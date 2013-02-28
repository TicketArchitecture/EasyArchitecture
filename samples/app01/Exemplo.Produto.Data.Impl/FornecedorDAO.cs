using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Exemplo.Produto.Data.TO;
using Framework.Data;
using Framework.Log;

namespace Exemplo.Produto.Data.Impl
{
    public class FornecedorDAO : IFornecedorDAO
    {
        private const string ConnectionString = "Exemplo.Produto";

		public IList<FornecedorTO> ObterTodos ()
        {
            IList<FornecedorTO> listTO = new List<FornecedorTO>();

            const string statement = "SELECT [DataCadastro], [Id], [Nome], [Telefone] FROM [Fornecedor] WITH (NOLOCK) ";
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

		public FornecedorTO Obter (int id)
        {
            LogManager.LogEntryParameters(id);

            FornecedorTO to = null;

            List<SqlParameter> parameters = new List<SqlParameter> { 
				new SqlParameter("@id",SqlDbType.Int){Value = id} 
            };
            
            const string statement = "SELECT [DataCadastro], [Id], [Nome], [Telefone] FROM [Fornecedor] WITH (NOLOCK) WHERE [Id] = @id ";
            LogManager.LogSQL(statement, parameters);

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(
                ConnectionString, CommandType.Text, statement, parameters.ToArray()))
                if (rdr.Read())
                {
                    to = ExtractData(rdr);
                }

            return to;
        }

		public void Inserir (FornecedorTO to)
        {
            LogManager.LogEntryParameters(to);

            List<SqlParameter> parameters = new List<SqlParameter>{
				new SqlParameter("@DataCadastro",SqlDbType.DateTime){Value = to.DataCadastro ??(object) DBNull.Value}, 
				new SqlParameter("@Id",SqlDbType.Int){Value = to.Id}, 
				new SqlParameter("@Nome",SqlDbType.VarChar,50){Value = to.Nome}, 
				new SqlParameter("@Telefone",SqlDbType.VarChar,50){Value = to.Telefone ??(object) DBNull.Value}
            };
            
            const string statement = "INSERT INTO [Fornecedor] ([DataCadastro], [Nome], [Telefone]) VALUES (@DataCadastro, @Nome, @Telefone);SELECT SCOPE_IDENTITY()";
            LogManager.LogSQL(statement, parameters);

            var returnCode = SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, statement, parameters.ToArray());
            LogManager.LogReturn(returnCode);

            to.Id = System.Convert.ToInt32(returnCode);
        }

		public void Atualizar (FornecedorTO to)
        {
            LogManager.LogEntryParameters(to);

            List<SqlParameter> parameters = new List<SqlParameter>{ 
				new SqlParameter("@DataCadastro",SqlDbType.DateTime){Value = to.DataCadastro ??(object) DBNull.Value}, 
				new SqlParameter("@Id",SqlDbType.Int){Value = to.Id}, 
				new SqlParameter("@Nome",SqlDbType.VarChar,50){Value = to.Nome}, 
				new SqlParameter("@Telefone",SqlDbType.VarChar,50){Value = to.Telefone ??(object) DBNull.Value} 
            };

            const string statement = "UPDATE [Fornecedor] SET [DataCadastro] = @DataCadastro, [Nome] = @Nome, [Telefone] = @Telefone WHERE [Id] = @Id ";
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

            const string statement = "DELETE FROM [Fornecedor] WHERE [Id] = @id ";
            LogManager.LogSQL(statement, parameters);

            var afectedRows = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, statement, parameters.ToArray());
            LogManager.LogReturn(afectedRows);
        }        



        private static FornecedorTO ExtractData(IDataRecord rdr)
        {
            return new FornecedorTO
            {
				DataCadastro =  rdr.IsDBNull(0)? null :(DateTime?)rdr.GetDateTime(0), 
				Id = rdr.GetInt32(1), 
				Nome = rdr.GetString(2), 
				Telefone =  rdr.IsDBNull(3)? null :(string)rdr.GetString(3)
            };
        }

    }
}