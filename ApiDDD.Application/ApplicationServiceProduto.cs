using System;
using System.Collections.Generic;
using ApiDDD.Application.DTO;
using ApiDDD.Application.Interface;
using ApiDDD.Domain.ApiDDD.Domain.Core.Interfaces.Service;
using ApiDDD.Domain.Entities;
using AutoMapper;

namespace ApiDDD.Application
{
	public class ApplicationServiceProduto : IApplicationServiceProduto
	{
        private readonly IServiceProduto _serviceProduto;
        private readonly IMapper _mapper;

        public ApplicationServiceProduto(IServiceProduto serviceProduto, IMapper mapper)
        {
            _serviceProduto = serviceProduto;
            _mapper = mapper;
        }

        public IEnumerable<ProdutoDTO> GetAll()
        {
            var produtos = _serviceProduto.GetAll();

            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public ProdutoDTO GetByCodigo(int codigo)
        {
            Produto produto = _serviceProduto.GetByCodigo(codigo);

            return _mapper.Map<ProdutoDTO>(produto);
        }

        public void Remove(ProdutoDTO produtoDTO)
        {
            produtoDTO.Situacao = false;

            Produto produto = _mapper.Map<Produto>(produtoDTO);

            _serviceProduto.Update(produto);
        }

        public void Add(ProdutoDTO produtoDTO)
        {
            ValidarRegras(produtoDTO);

            Produto produto = _mapper.Map<Produto>(produtoDTO);

            if (produto.Codigo == 0)
            {
                produto.Codigo = _serviceProduto.GetNextCodigo();
            }

            _serviceProduto.Add(produto);
        }

        public void Update(ProdutoDTO produtoDTO)
        {
            ValidarRegras(produtoDTO);

            Produto produto = _mapper.Map<Produto>(produtoDTO);

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