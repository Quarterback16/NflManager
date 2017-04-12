using Domain.Seasons;

namespace Application.Seasons.Commands.CreateSeason.Factory
{
	public class SeasonFactory : ISeasonFactory
	{
		public Season Create( string year )
		{
			var season = new Season()
			{
				Year = year
			};
			return season;
		}
	}
}
