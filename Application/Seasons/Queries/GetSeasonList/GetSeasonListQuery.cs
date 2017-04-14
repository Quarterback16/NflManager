using Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Seasons.Queries.GetSeasonList
{
	public class GetSeasonListQuery : IGetSeasonListQuery
	{
		private readonly ISeasonRepository _repository;

		public GetSeasonListQuery(ISeasonRepository repository )
		{
			_repository = repository ?? throw new ArgumentNullException( nameof( repository ) );
		}

		public List<SeasonModel> Execute()
		{
			var seasons = _repository.GetAll()
				.Select( p => new SeasonModel()
				{
					Year = p.Year
				} );

			return seasons.ToList();
		}
	}
}
