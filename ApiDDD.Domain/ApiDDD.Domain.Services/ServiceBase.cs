using System;
using System.Collections.Generic;
using ApiDDD.Domain.ApiDDD.Domain.Core.Interfaces.Service;
using ApiDDD.Domain.Core.Interfaces.Repository;

namespace ApiDDD.Domain.ApiDDD.Domain.Services
{
	public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
	{
        private readonly IRepositoryBase<TEntity> _repositoryBase;

		public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
		{
            _repositoryBase = repositoryBase;
        }

        public IEnumerable<TEntity> GetAll(int skip, int take)
        {
            return _repositoryBase.GetAll(skip, take);
        }

        public TEntity GetByCodigo(int codigo)
        {
            return _repositoryBase.GetByCodigo(codigo);
        }

        public void Add(TEntity obj)
        {
            _repositoryBase.Add(obj);
        }

        public void Update(TEntity obj)
        {
            _repositoryBase.Update(obj);
        }
    }
}

