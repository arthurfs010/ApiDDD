using System;
using ApiDDD.Domain.Entities;

namespace ApiDDD.Domain.ApiDDD.Domain.Core.Interfaces.Service
{
    public interface IServiceProduto : IServiceBase<Produto>
    {
        int GetNextCodigo();
    }
}

