using System;
using System.ComponentModel;
using ApiDDD.Application;
using ApiDDD.Application.Interface;
using ApiDDD.Application.Mapper;
using ApiDDD.Domain.ApiDDD.Domain.Core.Interfaces.Service;
using ApiDDD.Domain.ApiDDD.Domain.Services;
using ApiDDD.Domain.Core.Interfaces.Repository;
using ApiDDD.Infraestructure.Data.Repositories;
using Autofac;
using AutoMapper;

namespace ApiDDD.Infraestructure.CrossCutting.IOC
{
	public class ConfigurationIOC
	{
		public static void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ApplicationServiceProduto>().As<IApplicationServiceProduto>();
			builder.RegisterType<ServiceProduto>().As<IServiceProduto>();
			builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();

			builder.Register(reg => new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new MapperProduto());
			}));

			builder.Register(reg => reg.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
	}
}

