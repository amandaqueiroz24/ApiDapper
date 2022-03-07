using ApiDapper.Domain.Model;
using ApiDapper.Domain.Repositories;
using ApiDapper.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiDapper.Application
{
	public class BrandService : IBrandService
	{
		BrandReadOnlyRepository _brandReadOnlyRepository;

		public BrandService(BrandReadOnlyRepository brandReadOnlyRepository)
		{
			_brandReadOnlyRepository = brandReadOnlyRepository;
		}

		public async Task<IEnumerable<Brand>> ListBrand()
		{
			var brand = await _brandReadOnlyRepository.ListBrand();

			return brand;
		}

		public async Task<bool> CreateBrand(Brand brand)
		{
			var sucess = await _brandReadOnlyRepository.CreateBrand(brand);

			return sucess;
		}

		public async Task<bool> UpdateBrand(Int32 id, Brand brand)
		{
			var sucess = await _brandReadOnlyRepository.UpdateBrand(id, brand);

			return sucess;
		}

		public async Task<bool> DeleteBrand(Int32 id)
		{
			var sucess = await _brandReadOnlyRepository.DeleteBrand(id);

			return sucess;
		}
	}
}
