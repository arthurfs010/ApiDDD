using System;
using ApiDDD.Domain.ApiDDD.Domain.Core.Interfaces.Service;
using ApiDDD.Domain.Core.Interfaces.Repository;
using ApiDDD.Domain.Entities;

namespace ApiDDD.Domain.ApiDDD.Domain.Services
{
	public class ServiceProduto : ServiceBase<Produto>, IServiceProduto
	{
		private readonly IRepositoryProduto _repositoryProduto;

        public ServiceProduto(IRepositoryProduto repositoryProduto)
			: base(repositoryProduto)
		{
			_repositoryProduto = repositoryProduto;
		}

        public int GetNextCodigo()
        {
            try
            {
                return _repositoryProduto.GetNextCodigo();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("refused") ||
                    ex.InnerException.InnerException.Message.Contains("recusada"))
                    throw new Exception("Erro ao conectar-se ao banco de dados! Verifique.");

                throw new Exception("Erro ao pegar novo código!");
            }
        }
    }
}

