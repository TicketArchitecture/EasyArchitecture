using System;

namespace Exemplo.Produto.Application.Contracts.DTOs
{
    public class ProdutoDTO
    {
        public long Id { get;  set; }
        public DateTime? DataCadastro { get;  set; }
        public string Descricao { get;  set; }
        public long? IdCategoria { get;  set; }
        public long? IdFornecedor { get;  set; }
        public string Nome { get;  set; }
    }
}