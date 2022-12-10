using System;
using System.Collections.Generic;
using System.Linq;
using ApiDDD.Application.DTO;
using ApiDDD.Application.Interface.Mapper;
using ApiDDD.Domain.Entities;

namespace ApiDDD.Application.Mappper
{
	public class MapperProduto : IMapperProduto
    {
        public Produto MapperDTOToEntity(ProdutoDTO produtoDTO)
        {
            Produto produto = new Produto()
            {
                Codigo = produtoDTO.Codigo,
                Descricao = produtoDTO.Descricao,
                Situacao = produtoDTO.Situacao,
                DataFabricacao = produtoDTO.DataFabricacao,
                DataValidade = produtoDTO.DataValidade,
                CodigoFornecedor = produtoDTO.CodigoFornecedor,
                DescricaoFornecedor = produtoDTO.DescricaoFornecedor,
                CNPJFornecedor = produtoDTO.CNPJFornecedor
            };

            return produto;
        }

        public ProdutoDTO MapperEntityToDTO(Produto produto)
        {
            ProdutoDTO produtoDTO = new ProdutoDTO()
            {
                Codigo = produto.Codigo,
                Descricao = produto.Descricao,
                Situacao = produto.Situacao,
                DataFabricacao = produto.DataFabricacao,
                DataValidade = produto.DataValidade,
                CodigoFornecedor = produto.CodigoFornecedor,
                DescricaoFornecedor = produto.DescricaoFornecedor,
                CNPJFornecedor = produto.CNPJFornecedor
            };

            return produtoDTO;
        }

        public IEnumerable<ProdutoDTO> MapperListProdutosDTO(IEnumerable<Produto> produtos)
        {
            IEnumerable<ProdutoDTO> produtosDTO = produtos.Select(produto =>
                new ProdutoDTO()
                {
                    Codigo = produto.Codigo,
                    Descricao = produto.Descricao,
                    Situacao = produto.Situacao,
                    DataFabricacao = produto.DataFabricacao,
                    DataValidade = produto.DataValidade,
                    CodigoFornecedor = produto.CodigoFornecedor,
                    DescricaoFornecedor = produto.DescricaoFornecedor,
                    CNPJFornecedor = produto.CNPJFornecedor
                }
            );

            return produtosDTO;
        }
    }
}

