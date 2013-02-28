using System;

namespace Exemplo.Produto.Domain.Entities
{
    public class Produto
    {
        public virtual int Id { get; set; }
        public virtual DateTime? DataCadastro { get; set; }
        public virtual string Descricao { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual string Nome { get; set; }
    }
}