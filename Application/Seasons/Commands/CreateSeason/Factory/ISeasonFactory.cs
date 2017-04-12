using Domain.Seasons;

namespace Application.Seasons.Commands.CreateSeason.Factory
{
	public interface ISeasonFactory
	{
		Season Create( string year );
	}
}
