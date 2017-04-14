using Domain.Seasons;
using Application.Seasons.WriteModel.Commands;
using Application.Seasons.Handlers;
using Tests.Extensions.TestHelpers;
using System;
using System.Collections.Generic;
using Common.CQRSlite.Events;
using Domain.Seasons.Events;
using NUnit.Framework;
using System.Linq;

namespace Tests.WriteModel
{
	public class WhenSeasonCreated : Specification<Season, SeasonCommandHandlers, CreateSeason>
	{
		private Guid _id;
		protected override SeasonCommandHandlers BuildHandler()
		{
			return new SeasonCommandHandlers( Session );
		}

		protected override IEnumerable<IEvent> Given()
		{
			_id = Guid.NewGuid();
			return new List<IEvent>();
		}

		protected override CreateSeason When()
		{
			return new CreateSeason( _id, "1959" );
		}

		[Then]
		public void Should_create_one_event()
		{
			Assert.AreEqual( 1, PublishedEvents.Count );
		}

		[Then]
		public void Should_save_year()
		{
			Assert.AreEqual( "1959", ( ( SeasonCreated ) PublishedEvents.First() ).Year );
		}
	}
}
