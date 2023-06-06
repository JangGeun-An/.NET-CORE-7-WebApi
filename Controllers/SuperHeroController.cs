using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDotNet7.Services.SuperHeroService;

namespace WebApiDotNet7.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController : ControllerBase
	{
		#region 종속성 부여
		private readonly ISuperHeroService _superHeroService;

		public SuperHeroController(ISuperHeroService superHeroService) 
		{
			_superHeroService = superHeroService;
		}
		#endregion 종속성 부여

		#region READ ALL
		[HttpGet]
		public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
		{
			return await _superHeroService.GetAllHeroes();
		}
		#endregion READ ALL

		#region READ SINGLE
		[HttpGet("{id}")]
		public async Task<ActionResult<SuperHero>> GetSingleHeroes(int id)
		{
			var result = await _superHeroService.GetSingleHeroes(id);
			if (result is null) return NotFound("해당 히어로는 찾을 수 없습니다.");

			return Ok(result);
		}
		#endregion READ SINGLE

		#region INSERT
		[HttpPost]
		public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
		{
			var result = await _superHeroService.AddHero(hero);
			return Ok(result);
		}
		#endregion INSERT

		#region UPDATE
		[HttpPut("{id}")]
		public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
		{
			var result = await _superHeroService.UpdateHero(id, request);
			if (result is null) return NotFound("해당 히어로는 찾을 수 없습니다.");

			return Ok(result);
		}
		#endregion UPDATE

		#region DELETE
		[HttpDelete("{id}")]
		public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
		{
			var result = await _superHeroService.DeleteHero(id);
			if (result is null) 
				return NotFound("히어로가 없습니다.");

			return Ok(result);
		}
		#endregion DELETE
	}
}
