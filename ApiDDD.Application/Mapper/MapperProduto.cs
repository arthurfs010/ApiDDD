using System;
using ApiDDD.Application.DTO;
using ApiDDD.Domain.Entities;
using AutoMapper;

namespace ApiDDD.Application.Mapper
{
	public class MapperProduto : Profile
	{
		public MapperProduto()
		{
			CreateMap<ProdutoDTO, Produto>();
			CreateMap<Produto, ProdutoDTO>();
        }
	}
}

