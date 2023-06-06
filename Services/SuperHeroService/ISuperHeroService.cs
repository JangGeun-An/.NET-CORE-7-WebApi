using Microsoft.AspNetCore.Mvc;

namespace WebApiDotNet7.Services.SuperHeroService
{
	public interface ISuperHeroService
	{
		Task<List<SuperHero>> GetAllHeroes();
		Task<SuperHero>? GetSingleHeroes(int id);
		Task<List<SuperHero>> AddHero(SuperHero hero);
		Task<List<SuperHero>>? UpdateHero(int id, SuperHero request);
		Task<List<SuperHero>>? DeleteHero(int id);
	}
}
