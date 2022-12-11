using System;
using System.Collections.Generic;
using System.Linq;
using ApiDDD.Application.DTO;

namespace ApiDDD.Application.Interface
{
	public interface IApplicationServiceProduto
	{
		void Add(ProdutoDTO produtoDTO);

		void Remove(ProdutoDTO produto);

		void Update(ProdutoDTO produtoDTO);

		IEnumerable<ProdutoDTO> GetAll(int skip, int take);

		ProdutoDTO GetByCodigo(int codigo);
	}
}

