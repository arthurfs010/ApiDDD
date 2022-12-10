using System;
using System.Collections.Generic;
using ApiDDD.Application.DTO;

namespace ApiDDD.Application.Interface
{
	public interface IApplicationServiceProduto
	{
		void Add(ProdutoDTO produtoDTO);

		void Remove(ProdutoDTO produto);

		void Update(ProdutoDTO produtoDTO);

		IEnumerable<ProdutoDTO> GetAll();

		ProdutoDTO GetByCodigo(long codigo);
	}
}

