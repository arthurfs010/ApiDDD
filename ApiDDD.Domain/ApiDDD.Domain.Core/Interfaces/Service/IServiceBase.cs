using System;
using System.Collections.Generic;
using ApiDDD.Domain.Entities;

namespace ApiDDD.Domain.ApiDDD.Domain.Core.Interfaces.Service
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        IEnumerable<TEntity> GetAll(int skip, int take);

        TEntity GetByCodigo(int codigo);
    }
}

