using System;
using System.Collections.Generic;

namespace ApiDDD.Domain.Core.Interfaces.Repository
{
	public interface IRepositoryBase<TEntity> where TEntity : class
	{
		void Add(TEntity obj);

		void Update(TEntity obj);

        IEnumerable<TEntity> GetAll();

		TEntity GetByCodigo(int codigo);
	}
}

