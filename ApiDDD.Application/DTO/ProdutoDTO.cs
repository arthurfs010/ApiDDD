using System;
namespace ApiDDD.Application.DTO
{
	public class ProdutoDTO
	{
        public int Codigo { get; set; }

        public string Descricao { get; set; } = "";

        public bool Situacao { get; set; }

        public DateTime DataFabricacao { get; set; }

        public DateTime? DataValidade { get; set; }

        public int? CodigoFornecedor { get; set; }

        public string DescricaoFornecedor { get; set; } = "";

        public long? CNPJFornecedor { get; set; }
    }
}

