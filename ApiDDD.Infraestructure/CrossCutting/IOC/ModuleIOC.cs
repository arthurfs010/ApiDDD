using System;
using Autofac;

namespace ApiDDD.Infraestructure.CrossCutting.IOC
{
	public class ModuleIOC : Module
    {
		protected override void Load(ContainerBuilder builder)
		{
			ConfigurationIOC.Load(builder);
		}
	}
}

