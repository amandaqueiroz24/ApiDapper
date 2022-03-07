using ApiDapper.Application;
using ApiDapper.Domain.Repositories;
using ApiDapper.Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDapper.Application.Microsoft.Extensions.DependencyInjection
{
	public static class ApplicationRepositoryServiceColletion
	{
		public static IServiceCollection AddApplicationRepository(this IServiceCollection services,
																 ApplicationConfiguration applicationConfiguration)
		{
			if (services == null)
				throw new ArgumentException(nameof(services));

			services.AddSingleton(applicationConfiguration);
			services.AddScoped<IBrandService, BrandService>();
			//services.AddSingleton(new RegisterMapping());

			return services;
		}
	}
}
