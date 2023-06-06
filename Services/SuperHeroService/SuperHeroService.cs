using Microsoft.EntityFrameworkCore;
using WebApiDotNet7.Data;

namespace WebApiDotNet7.Services.SuperHeroService
{
	public class SuperHeroService : ISuperHeroService
	{
		#region 종속성 부여
		private readonly DataContext _context;

		public SuperHeroService(DataContext context) 
		{
			_context = context;
		}
		#endregion 종속성 부여

		#region INSERT
		public async Task<List<SuperHero>> AddHero(SuperHero hero)
		{
			_context.Superherodb.Add(hero);
			await _context.SaveChangesAsync();
			return await _context.Superherodb.ToListAsync();
		}
		#endregion INSERT

		#region DELETE
		public async Task<List<SuperHero>?> DeleteHero(int id)
		{
			var hero = await _context.Superherodb.FindAsync(id);
			if (hero is null)
				return null;

			_context.Superherodb.Remove(hero);
			await _context.SaveChangesAsync();

			return await _context.Superherodb.ToListAsync();
		}
		#endregion DELETE

		#region READ ALL
		public async Task<List<SuperHero>> GetAllHeroes()
		{
			var heroes = await _context.Superherodb.ToListAsync();
			return heroes;
		}
		#endregion READ ALL

		#region READ SINGLE
		public async Task<SuperHero?> GetSingleHeroes(int id)
		{
			var hero = await _context.Superherodb.FindAsync(id);
			if (hero is null) return null;
			return hero;
		}
		#endregion READ SINGLE

		#region UPDATE
		public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero request)
		{
			var hero = await _context.Superherodb.FindAsync(id);
			if (hero is null) return null;

			hero.FirstName = request.FirstName;
			hero.LastName = request.LastName;
			hero.Name = request.Name;
			hero.Place = request.Place;

			await _context.SaveChangesAsync();

			return await _context.Superherodb.ToListAsync();
		}
		#endregion UPDATE
	}
}
