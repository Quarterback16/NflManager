using System;
using System.Collections.Generic;

namespace Common.CQRSlite.Events
{
	public interface IEventStore
	{
		//  you can save events
		void Save<T>( IEnumerable<IEvent> events );

		//  you can get all events for a particular aggregate object
		IEnumerable<IEvent> Get<T>( Guid aggregateId, int fromVersion );
	}
}
