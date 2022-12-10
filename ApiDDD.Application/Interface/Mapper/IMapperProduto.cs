using System;
using System.Collections;
using System.Collections.Generic;
using ApiDDD.Application.DTO;
using ApiDDD.Domain.Entities;

namespace ApiDDD.Application.Interface.Mapper
{
	public interface IMapperProduto
	{
		Produto MapperDTOToEntity(ProdutoDTO produtoDTO);

		IEnumerable<ProdutoDTO> MapperListProdutosDTO(IEnumerable<Produto> produtos);

		ProdutoDTO MapperEntityToDTO(Produto produto); 
	}
}

