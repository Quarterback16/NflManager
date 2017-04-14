using System;
using Common.CQRSlite.Domain;

namespace Common.CQRSlite.Snapshots
{
	public interface ISnapshotStrategy
	{
		bool ShouldMakeSnapShot( AggregateRoot aggregate );
		bool IsSnapshotable( Type aggregateType );
	}
}
