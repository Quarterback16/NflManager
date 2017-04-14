using Common.CQRSlite.Domain;
using Domain.Seasons.Events;
using System;

namespace Domain.Seasons
{
	/// <summary>
	///   The Season Entity
	/// </summary>
	public class Season : AggregateRoot
	{
		public string Year { get; set; }

		public Season(Guid id, string year)
		{
			Id = id;
			Year = year;
			// the season created event is born
			var birthEvent = new SeasonCreated( id, year );
			ApplyChange( birthEvent );  // do what u do when this happens
		}
	}
}
