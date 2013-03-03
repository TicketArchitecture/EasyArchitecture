using System;

namespace Exemplo.Produto.Domain.Entities
{
    public class Fornecedor
    {
        public virtual long Id { get; set; }
        public virtual DateTime? DataCadastro { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Telefone { get; set; }
    }
}