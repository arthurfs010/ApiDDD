using System;
using System.Collections.Generic;
using ApiDDD.Application.DTO;
using ApiDDD.Application.Interface;
using ApiDDD.Application.Interface.Mapper;
using ApiDDD.Domain.ApiDDD.Domain.Core.Interfaces.Service;
using ApiDDD.Domain.Entities;

namespace ApiDDD.Application
{
	public class ApplicationServiceProduto : IApplicationServiceProduto
	{
        private readonly IServiceProduto _serviceProduto;
        private readonly IMapperProduto _mapperProduto;

        public ApplicationServiceProduto(IServiceProduto serviceProduto, IMapperProduto mapperProduto)
        {
            _serviceProduto = serviceProduto;
            _mapperProduto = mapperProduto;
        }

        public IEnumerable<ProdutoDTO> GetAll()
        {
            var produtos = _serviceProduto.GetAll();

            return _mapperProduto.MapperListProdutosDTO(produtos);
        }

        public ProdutoDTO GetByCodigo(long codigo)
        {
            Produto produto = _serviceProduto.GetByCodigo(codigo);

            return _mapperProduto.MapperEntityToDTO(produto);
        }

        public void Remove(ProdutoDTO produtoDTO)
        {
            produtoDTO.Situacao = false;

            Produto produto = _mapperProduto.MapperDTOToEntity(produtoDTO);

            _serviceProduto.Update(produto);
        }

        public void Add(ProdutoDTO produtoDTO)
        {
            ValidarRegras(produtoDTO);

            Produto produto = _mapperProduto.MapperDTOToEntity(produtoDTO);

            if (produto.Codigo == 0)
            {
                produto.Codigo = _serviceProduto.GetNextCodigo();
            }

            _serviceProduto.Add(produto);
        }

        public void Update(ProdutoDTO produtoDTO)
        {
            ValidarRegras(produtoDTO);

            Produto produto = _mapperProduto.MapperDTOToEntity(produtoDTO);

            _serviceProduto.Update(produto);
        }

        private void ValidarRegras(ProdutoDTO produtoDTO)
        {
            if (produtoDTO.DataValidade != null &&
                (produtoDTO.DataFabricacao.Date >= produtoDTO.DataValidade?.Date))
            {
                throw new Exception("A data de fabricação não pode ser maior que a data de validade! Verifique.");
            }

            if (string.IsNullOrEmpty(produtoDTO.Descricao))
            {
                throw new Exception("Campo descrição obrigatório! Verifique.");
            }
        }
    }
}