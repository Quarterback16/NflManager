﻿using System;
using System.Linq;
using Common.CQRSlite.Domain.Exception;
using Common.CQRSlite.Events;
using Common.CQRSlite.Domain.Factories;

namespace Common.CQRSlite.Domain
{
	public class Repository : IRepository
	{
		private readonly IEventStore _eventStore;
		private readonly IEventPublisher _publisher;

		public Repository( IEventStore eventStore )
		{
			_eventStore = eventStore ?? throw new ArgumentNullException( nameof( eventStore ) );
		}

		[Obsolete( "The eventstore should publish events after saving" )]
		public Repository( IEventStore eventStore, IEventPublisher publisher )
		{
			_eventStore = eventStore ?? throw new ArgumentNullException( nameof( eventStore ) );
			_publisher = publisher ?? throw new ArgumentNullException( nameof( publisher ) );
		}

		public void Save<T>( T aggregate, int? expectedVersion = null ) where T : AggregateRoot
		{
			if ( expectedVersion != null && _eventStore.Get<T>( aggregate.Id, expectedVersion.Value ).Any() )
			{
				throw new ConcurrencyException( aggregate.Id );
			}

			var changes = aggregate.FlushUncommitedChanges();
			_eventStore.Save<T>( changes );

			if ( _publisher != null )
			{
				foreach ( var @event in changes )
				{
					_publisher.Publish( @event );
				}
			}
		}

		public T Get<T>( Guid aggregateId ) where T : AggregateRoot
		{
			return LoadAggregate<T>( aggregateId );
		}

		private T LoadAggregate<T>( Guid id ) where T : AggregateRoot
		{
			var events = _eventStore.Get<T>( id, -1 );
			if ( !events.Any() )
			{
				throw new AggregateNotFoundException( typeof( T ), id );
			}

			var aggregate = AggregateFactory.CreateAggregate<T>();
			aggregate.LoadFromHistory( events );
			return aggregate;
		}
	}
}
