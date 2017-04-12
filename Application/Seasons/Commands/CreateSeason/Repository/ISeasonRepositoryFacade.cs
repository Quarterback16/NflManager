using Domain.Seasons;

namespace Application.Seasons.Commands.CreateSeason.Repository
{
	public interface ISeasonRepositoryFacade
	{
		void AddSeason( Season season );
	}
}
