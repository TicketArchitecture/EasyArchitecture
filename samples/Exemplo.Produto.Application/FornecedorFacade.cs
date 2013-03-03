using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using EasyArchitecture.Mechanisms.Translation;
using Exemplo.Produto.Application.Contracts;
using Exemplo.Produto.Application.Contracts.DTOs;
using Exemplo.Produto.Domain.Repositories;

namespace Exemplo.Produto.Application
{
    public class FornecedorFacade : IFornecedorFacade
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorFacade(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public IList<FornecedorDTO> ObterTodos()
        {
            var entities = _fornecedorRepository.Get();

            var dtos = Translator.This(entities).To<IList<FornecedorDTO>>();

            return dtos;
        }

        public FornecedorDTO Obter(long id)
        {
            var entity = _fornecedorRepository.Get(new Domain.Entities.Fornecedor() { Id = id }).FirstOrDefault();

            var dto = Translator.This(entity).To<FornecedorDTO>();

            return dto;
        }

        public void Inserir(FornecedorDTO fornecedor)
        {
            Contract.Requires(!string.IsNullOrEmpty(fornecedor.Nome), "MSG0001");

            var entity = Translator.This(fornecedor).To<Domain.Entities.Fornecedor>();

            _fornecedorRepository.Save(entity);

            Translator.This(entity).To(fornecedor);
        }

        public void Excluir(long id)
        {
            var entity = _fornecedorRepository.Get(new Domain.Entities.Fornecedor() { Id = id }).FirstOrDefault();
            _fornecedorRepository.Delete(entity);
        }

        public void Atualizar(FornecedorDTO fornecedor)
        {
            Contract.Requires(!string.IsNullOrEmpty(fornecedor.Nome), "MSG0001");

            var entity = _fornecedorRepository.Get(new Domain.Entities.Fornecedor() { Id = fornecedor.Id }).FirstOrDefault();

            Translator.This(fornecedor).To(entity);

            _fornecedorRepository.Update(entity);
        }
    }
}