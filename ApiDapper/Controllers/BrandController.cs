using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDapper.Domain.Model;
using ApiDapper.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiDapper.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BrandController : ControllerBase
	{
		
		private readonly ILogger<BrandController> _logger;
		IBrandService _brandService;


		public BrandController(ILogger<BrandController> logger,
			IBrandService brandService
		)
		{
			_logger = logger;
			_brandService = brandService ?? throw new ArgumentNullException(nameof(brandService));
		}

		[HttpGet]
		public async Task<IEnumerable<Brand>> ListBrand()
		{
			var brand = await _brandService.ListBrand();

			return brand;
		}

		[HttpPost]
		public async Task<ActionResult> CreateBrand(Brand brand)
		{
			try
			{
				var brands = await _brandService.CreateBrand(brand);

				return Ok();
			}catch(Exception ex)
			{
				throw ex;
			}
		}

		[HttpPut]
		public async Task<ActionResult> UpdateBrand(Int32 id, [FromBody] Brand brand)
		{
			try
			{
				var brands = await _brandService.UpdateBrand(id, brand);

				return Ok();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[HttpDelete]
		public async Task<ActionResult> DeleteBrand(Int32 id)
		{
			try
			{
				var brands = await _brandService.DeleteBrand(id);

				return Ok();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
