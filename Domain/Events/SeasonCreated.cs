using System;
using Common.CQRSlite.Events;

namespace Domain.Seasons.Events
{
	public class SeasonCreated : IEvent
	{
		public readonly string Year;
		public SeasonCreated( Guid id, string year )
		{
			Id = id;
			Year = year;
		}

		public Guid Id { get; set; }
		public int Version { get; set; }
		public DateTimeOffset TimeStamp { get; set; }
	}
}
