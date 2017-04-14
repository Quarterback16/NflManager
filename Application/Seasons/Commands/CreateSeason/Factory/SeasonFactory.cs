using Domain.Seasons;
using System;

namespace Application.Seasons.Commands.CreateSeason.Factory
{
	public class SeasonFactory : ISeasonFactory
	{
		public Season Create( string year )
		{
			var season = new Season(new Guid(), year)
			{
				Year = year
			};
			return season;
		}
	}
}
