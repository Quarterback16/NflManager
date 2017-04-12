using Domain.Seasons;
using Application.Interfaces.Persistence;

namespace Application.Seasons.Commands.CreateSeason.Repository
{
	public class SeasonRepositoryFacade : ISeasonRepositoryFacade
	{
		private readonly ISeasonRepository _seasonRepository;
		public SeasonRepositoryFacade(
			ISeasonRepository seasonRepository)
		{
			_seasonRepository = seasonRepository;
		}

		public void AddSeason( Season season )
		{
			_seasonRepository.Add(season);
		}
	}
}
