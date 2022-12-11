using System;
using ApiDDD.Application.DTO;
using ApiDDD.Domain.Entities;
using AutoMapper;

namespace ApiDDD.Application.Mapper
{
	public class ModelToDtoMappingProduto : Profile
	{
        public ModelToDtoMappingProduto()
        {
            ProdutoDtoMap();
        }

        private void ProdutoDtoMap()
        {
            CreateMap<Produto, ProdutoDTO>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(pdto => pdto.Codigo))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(pdto => pdto.Descricao))
                .ForMember(dest => dest.DataValidade, opt => opt.MapFrom(pdto => pdto.DataValidade))
                .ForMember(dest => dest.DataFabricacao, opt => opt.MapFrom(pdto => pdto.DataFabricacao))
                .ForMember(dest => dest.CodigoFornecedor, opt => opt.MapFrom(pdto => pdto.CodigoFornecedor))
                .ForMember(dest => dest.DescricaoFornecedor, opt => opt.MapFrom(pdto => pdto.DescricaoFornecedor))
                .ForMember(dest => dest.CNPJFornecedor, opt => opt.MapFrom(pdto => pdto.CNPJFornecedor));
        }
    }
}

