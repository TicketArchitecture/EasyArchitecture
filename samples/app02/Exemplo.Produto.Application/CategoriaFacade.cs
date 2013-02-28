using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using EasyArchitecture.Mechanisms.Translation;
using Exemplo.Produto.Application.Contracts;
using Exemplo.Produto.Application.Contracts.DTOs;
using Exemplo.Produto.Domain.Repositories;

namespace Exemplo.Produto.Application
{
    public class CategoriaFacade : ICategoriaFacade
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaFacade(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IList<CategoriaDTO> ObterTodos()
        {
            var entities = _categoriaRepository.Get();

            var dtos = Translator.This(entities).To<IList<CategoriaDTO>>();

            return dtos;
        }

        public CategoriaDTO Obter(int id)
        {
            var entity = _categoriaRepository.Get(new Domain.Entities.Categoria() { Id = id }).FirstOrDefault();

            var dto = Translator.This(entity).To<CategoriaDTO>();

            return dto;
        }

        public void Inserir(CategoriaDTO categoria)
        {
            Contract.Requires(!string.IsNullOrEmpty(categoria.Descricao), "MSG0001");

            var entity = Translator.This(categoria).To<Domain.Entities.Categoria>();

            _categoriaRepository.Save(entity);

            Translator.This(entity).To(categoria);
        }

        public void Excluir(int id)
        {
            var entity = _categoriaRepository.Get(new Domain.Entities.Categoria() { Id = id }).FirstOrDefault();
            _categoriaRepository.Delete(entity);
        }

        public void Atualizar(CategoriaDTO categoria)
        {
            Contract.Requires(!string.IsNullOrEmpty(categoria.Descricao), "MSG0001");

            var entity = _categoriaRepository.Get(new Domain.Entities.Categoria() { Id = categoria.Id }).FirstOrDefault();

            Translator.This(categoria).To(entity);

            _categoriaRepository.Update(entity);
        }
    }
}