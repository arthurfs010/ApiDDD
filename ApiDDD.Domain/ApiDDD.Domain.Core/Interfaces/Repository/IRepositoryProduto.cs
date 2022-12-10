using System;
using System.Runtime.CompilerServices;
using ApiDDD.Domain.Entities;

namespace ApiDDD.Domain.Core.Interfaces.Repository
{
	public interface IRepositoryProduto : IRepositoryBase<Produto>
    {
		int GetNextCodigo();
	}
}

