using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Exemplo.Produto.Data.TO;
using Framework.Data;
using Framework.Log;

namespace Exemplo.Produto.Data.Impl
{
    public class CategoriaDAO : ICategoriaDAO
    {
        private const string ConnectionString = "Exemplo.Produto";

		public IList<CategoriaTO> ObterTodos ()
        {
            IList<CategoriaTO> listTO = new List<CategoriaTO>();

            const string statement = "SELECT [Descricao], [Id] FROM [Categoria] WITH (NOLOCK) ";
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

		public CategoriaTO Obter (int id)
        {
            LogManager.LogEntryParameters(id);

            CategoriaTO to = null;

            List<SqlParameter> parameters = new List<SqlParameter> { 
				new SqlParameter("@id",SqlDbType.Int){Value = id} 
            };
            
            const string statement = "SELECT [Descricao], [Id] FROM [Categoria] WITH (NOLOCK) WHERE [Id] = @id ";
            LogManager.LogSQL(statement, parameters);

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(
                ConnectionString, CommandType.Text, statement, parameters.ToArray()))
                if (rdr.Read())
                {
                    to = ExtractData(rdr);
                }

            return to;
        }

		public void Inserir (CategoriaTO to)
        {
            LogManager.LogEntryParameters(to);

            List<SqlParameter> parameters = new List<SqlParameter>{
				new SqlParameter("@Descricao",SqlDbType.VarChar,50){Value = to.Descricao}, 
				new SqlParameter("@Id",SqlDbType.Int){Value = to.Id}
            };
            
            const string statement = "INSERT INTO [Categoria] ([Descricao]) VALUES (@Descricao);SELECT SCOPE_IDENTITY()";
            LogManager.LogSQL(statement, parameters);

            var returnCode = SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, statement, parameters.ToArray());
            LogManager.LogReturn(returnCode);

            to.Id = System.Convert.ToInt32(returnCode);
        }

		public void Atualizar (CategoriaTO to)
        {
            LogManager.LogEntryParameters(to);

            List<SqlParameter> parameters = new List<SqlParameter>{ 
				new SqlParameter("@Descricao",SqlDbType.VarChar,50){Value = to.Descricao}, 
				new SqlParameter("@Id",SqlDbType.Int){Value = to.Id} 
            };

            const string statement = "UPDATE [Categoria] SET [Descricao] = @Descricao WHERE [Id] = @Id ";
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

            const string statement = "DELETE FROM [Categoria] WHERE [Id] = @id ";
            LogManager.LogSQL(statement, parameters);

            var afectedRows = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, statement, parameters.ToArray());
            LogManager.LogReturn(afectedRows);
        }        



        private static CategoriaTO ExtractData(IDataRecord rdr)
        {
            return new CategoriaTO
            {
				Descricao = rdr.GetString(0), 
				Id = rdr.GetInt32(1)
            };
        }

    }
}