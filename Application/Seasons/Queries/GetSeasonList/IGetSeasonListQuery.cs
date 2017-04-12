using System.Collections.Generic;

namespace Application.Seasons.Queries.GetSeasonList
{
	public interface IGetSeasonListQuery
	{
		List<SeasonModel> Execute();
	}
}
