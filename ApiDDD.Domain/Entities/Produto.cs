using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDDD.Domain.Entities
{
	[Table("produto")]
	public class Produto
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("codigo")]
		public int Codigo { get; set; }

		[Required]
		[Column("descricao", TypeName = "character varying(200)")]
		public string Descricao { get; set; } = "";

        [Required]
        [Column("situacao")]
		public bool Situacao { get; set; }

        [Required]
        [Column("datafabricacao")]
		public DateTime DataFabricacao { get; set; }

        [Column("datavalidade")]
        public DateTime? DataValidade { get; set; }

		[Column("codigofornecedor")]
		public int? CodigoFornecedor { get; set; }

		[Column("descricaofornecedor", TypeName = "character varying(200)")]
		public string DescricaoFornecedor { get; set; } = "";

		[Column("cnpjfornecedor")]
		public long? CNPJFornecedor { get; set; }
	}
}

