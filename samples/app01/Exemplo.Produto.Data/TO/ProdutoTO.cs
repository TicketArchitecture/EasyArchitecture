using System;

namespace Exemplo.Produto.Data.TO
{
    public class ProdutoTO {

		public DateTime? DataCadastro { get;  set; }
		public string Descricao { get;  set; }
		public int Id { get;  set; }
		public int? IdCategoria { get;  set; }
		public int? IdFornecedor { get;  set; }
		public string Nome { get;  set; }
    }
}		