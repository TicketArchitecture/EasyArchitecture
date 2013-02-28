using System;

namespace Exemplo.Produto.Application.Contracts.DTOs
{
    public class FornecedorDTO
    {
        public DateTime? DataCadastro { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}