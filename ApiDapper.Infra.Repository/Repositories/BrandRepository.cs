using ApiDapper.Domain.Model;
using ApiDapper.Domain.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ApiDapper.Infra.Repository.Repositories
{
	public class BrandRepository : BrandReadOnlyRepository
	{
		private IConfiguration _configuration;
		private string _connection;
		public BrandRepository(IConfiguration configuration)
		{
			_configuration = configuration;
			_connection = _configuration.GetSection("Connection:connectionString").Value;

		}

		public async Task<IEnumerable<Brand>> ListBrand()
		{


			var query = $@"SELECT *
						   FROM BRAND
";

			using(var connection = new SqlConnection(_connection))
			{
				var brands = connection.Query<Brand>(query);

				return brands;
			}


		}

		public async Task<bool> CreateBrand(Brand brand)
		{
			try
			{

				var query = $@"INSERT INTO [BRAND] 
						VALUES(@description, @type)
";

				using (var connection = new SqlConnection(_connection))
				{
					var brands = connection.Execute(query, new
					{
						description = brand.Description,
						type = brand.Type

					});

					if (brands >= 1)
					{
						return true;
					}
					else
					{
						throw new Exception("Error");
					}

				}
			}catch(Exception ex)
			{
				throw ex;
			}

		}

		public async Task<bool> UpdateBrand(Int32 id, Brand brand)
		{

			try
			{
				var query = @"UPDATE [dbo].[BRAND] 
						SET [DESCRIPTION] = '@description', [TYPE] = '@type'
						WHERE [ID] = @idBrant
";

				using (var connection = new SqlConnection(_connection))
				{

					connection.Execute(query, new
					{
						idBrant = id,
						description = brand.Description,
						type = brand.Type

					});


					return true;
				}

			}catch(Exception ex)
			{
				throw ex;
			}
			}

		public async Task<bool> DeleteBrand(Int32 id)
		{

			try
			{
				var query = @"DELETE FROM [BRAND]
							WHERE Id = @id
";

				using (var connection = new SqlConnection(_connection))
				{

					connection.Execute(query, new
					{
						id = id,
						

					});


					return true;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
