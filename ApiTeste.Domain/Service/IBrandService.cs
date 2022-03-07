using ApiDapper.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiDapper.Domain.Service
{
	public interface IBrandService
	{
		Task<IEnumerable<Brand>> ListBrand();
		Task<bool> CreateBrand(Brand brand);
		Task<bool> UpdateBrand(Int32 id, Brand brand);
		Task<bool> DeleteBrand(Int32 id);
	}
}
