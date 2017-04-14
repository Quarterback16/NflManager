using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Common.CQRSlite.Domain;
using Common.CQRSlite.Events;
using Common.CQRSlite.Domain.Exception;
using Common.CQRSlite.Commands;
using Common.CQRSlite.Snapshots;

namespace Tests.Extensions.TestHelpers
{
	[TestFixture]
	public abstract class Specification<TAggregate, THandler, TCommand>
		where TAggregate : AggregateRoot  // the entity u r testing
		where THandler : class, ICommandHandler<TCommand>  // the command handler
		where TCommand : ICommand  // the command u r testing
	{

		protected TAggregate Aggregate { get; set; }
		protected ISession Session { get; set; }
		protected abstract IEnumerable<IEvent> Given();
		protected abstract TCommand When();
		protected abstract THandler BuildHandler();

		protected Snapshot Snapshot { get; set; }
		protected IList<IEvent> EventDescriptors { get; set; }
		protected IList<IEvent> PublishedEvents { get; set; }

		[SetUp]
		public void Run()
		{
			// we need a publisher
			var eventpublisher = new SpecEventPublisher();
			//  we need somewhere to save the events
			var eventstorage = new SpecEventStorage( eventpublisher, Given().ToList() );

			//  we need a snapshoting repository

			var snapshotstorage = new SpecSnapShotStorage( Snapshot );
			var snapshotStrategy = new DefaultSnapshotStrategy();
			var repository = new SnapshotRepository( 
				snapshotstorage, 
				snapshotStrategy, 
				new Repository( eventstorage ), 
				eventstorage );

			//  we need a context
			Session = new Session( repository );

			try
			{
				Aggregate = Session.Get<TAggregate>( Guid.Empty );
			}
			catch ( AggregateNotFoundException )
			{

			}

			var handler = BuildHandler();
			handler.Handle( When() );

			Snapshot = snapshotstorage.Snapshot;
			PublishedEvents = eventpublisher.PublishedEvents;
			EventDescriptors = eventstorage.Events;
		}

		//  this looks like a mock event publisher
		internal class SpecEventPublisher : IEventPublisher
		{
			public SpecEventPublisher()
			{
				PublishedEvents = new List<IEvent>();
			}

			public void Publish<T>( T @event ) where T : IEvent
			{
				PublishedEvents.Add( @event );
			}

			public IList<IEvent> PublishedEvents { get; set; }
		}

		//  this looks like a mock Event store
		internal class SpecEventStorage : IEventStore
		{
			private readonly IEventPublisher _publisher;

			public SpecEventStorage( IEventPublisher publisher, List<IEvent> events )
			{
				_publisher = publisher;
				Events = events;
			}

			public List<IEvent> Events { get; set; }

			public void Save<T>( IEnumerable<IEvent> events )
			{
				Events.AddRange( events );
				foreach ( var @event in events )
					_publisher.Publish( @event );
			}

			public IEnumerable<IEvent> Get<T>( Guid aggregateId, int fromVersion )
			{
				return Events.Where( x => x.Version > fromVersion );
			}
		}

		internal class SpecSnapShotStorage : ISnapshotStore
		{
			public SpecSnapShotStorage( Snapshot snapshot )
			{
				Snapshot = snapshot;
			}

			public Snapshot Snapshot { get; set; }

			public Snapshot Get( Guid id )
			{
				return Snapshot;
			}

			public void Save( Snapshot snapshot )
			{
				Snapshot = snapshot;
			}
		}
	}

}
