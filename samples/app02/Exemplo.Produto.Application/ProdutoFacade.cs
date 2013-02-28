using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using EasyArchitecture.Mechanisms.Translation;
using Exemplo.Produto.Application.Contracts;
using Exemplo.Produto.Application.Contracts.DTOs;
using Exemplo.Produto.Domain.Repositories;

namespace Exemplo.Produto.Application
{
    public class ProdutoFacade : IProdutoFacade
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoFacade(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void Inserir(ProdutoDTO produto)
        {
            Contract.Requires(!string.IsNullOrEmpty(produto.Nome ),"MSG0001");

            var entity = Translator.This(produto).To<Domain.Entities.Produto>();

            _produtoRepository.Save(entity);

            Translator.This(entity).To(produto);
        }

        public IList<ProdutoDTO> ObterTodos()
        {
            var entities = _produtoRepository.Get();

            var dtos = Translator.This(entities).To<IList<ProdutoDTO>>();
            
            return dtos;
        }

        public ProdutoDTO Obter(int id)
        {
            var entity = _produtoRepository.Get(new Domain.Entities.Produto(){Id = id}).FirstOrDefault();

            var dto = Translator.This(entity).To<ProdutoDTO>();

            return dto;
        }

        public void Atualizar(ProdutoDTO produto)
        {
            Contract.Requires(!string.IsNullOrEmpty(produto.Nome), "MSG0001");

            var entity = _produtoRepository.Get(new Domain.Entities.Produto() { Id = produto.Id }).FirstOrDefault();

            Translator.This(produto).To(entity);

            _produtoRepository.Update(entity);
        }

        public void Excluir(int id)
        {
            var entity = _produtoRepository.Get(new Domain.Entities.Produto() { Id = id }).FirstOrDefault();
            _produtoRepository.Delete(entity);
        }

        public void InserirProdutosIguais(ProdutoDTO produto)
        {
            Contract.Requires(!string.IsNullOrEmpty(produto.Nome), "MSG0001");

            var entity1 = Translator.This(produto).To<Domain.Entities.Produto>();
            var entity2 = Translator.This(produto).To<Domain.Entities.Produto>();
            var entity3= Translator.This(produto).To<Domain.Entities.Produto>();

            _produtoRepository.Save(entity1);
            _produtoRepository.Save(entity2);
            _produtoRepository.Save(entity3);

            Translator.This(entity1).To(produto);   
        }
    }
}
