using System;
using System.Collections.Generic;
using System.Linq;
using ApiDDD.Domain.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ApiDDD.Infraestructure.Data.Repositories
{
	public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
	{
		private readonly SqlContext _sqlContext;

        public RepositoryBase(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public void Add(TEntity obj)
        {
            try
            {
                _sqlContext.Set<TEntity>().Add(obj);
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar: " + ex);
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                _sqlContext.Set<TEntity>().Update(obj);
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar: " + ex);
            }
        }

        public IEnumerable<TEntity> GetAll(int skip, int take)
        {
            return _sqlContext.Set<TEntity>().Skip(skip).Take(take).ToList();
        }

        public TEntity GetByCodigo(int codigo)
        {
            return _sqlContext.Set<TEntity>().Find(codigo);
        }
    }
}

