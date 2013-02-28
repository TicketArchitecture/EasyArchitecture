using System;

namespace Exemplo.Produto.Application.Contracts.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get;  set; }
        public DateTime? DataCadastro { get;  set; }
        public string Descricao { get;  set; }
        public int? IdCategoria { get;  set; }
        public int? IdFornecedor { get;  set; }
        public string Nome { get;  set; }
    }
}