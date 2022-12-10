using System;
using System.Data.Common;
using System.Linq;
using ApiDDD.Domain.Core.Interfaces.Repository;
using ApiDDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ApiDDD.Infraestructure.Data.Repositories
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        private readonly SqlContext _sqlContext;

        public RepositoryProduto(SqlContext sqlContext)
            : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public int GetNextCodigo()
        {
            int codigo = 0;

            var con = _sqlContext.Database.GetDbConnection();
            con.Open();

            var command = con.CreateCommand();
            command.CommandText = "SELECT MAX(codigo) + 1 FROM produto";
            DbDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    codigo = reader.GetInt32(0);
                }
            }

            reader.Close();
            con.Close();

            return codigo;
        }
    }
}

