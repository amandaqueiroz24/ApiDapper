using ApiDapper.Domain.Repositories;
using ApiDapper.Domain.Service;
using ApiDapper.Infra.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDapper.Infra.Repository.Microsoft.Extensions.DependencyInjection
{
	public static class InfraRepositoryServiceColletion
	{
		public static IServiceCollection AddInfraRepository(this IServiceCollection services)
		{
			if (services == null)
				throw new ArgumentException(nameof(services));

			services.AddScoped<BrandReadOnlyRepository, BrandRepository>();
			//services.AddSingleton(new RegisterMapping());

			return services;
		}
	}
}
