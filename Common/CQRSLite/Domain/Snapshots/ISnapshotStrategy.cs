using System;

namespace Common.CQRSlite.Domain.Snapshots
{
	public interface ISnapshotStrategy
	{
		bool ShouldMakeSnapShot( AggregateRoot aggregate );
		bool IsSnapshotable( Type aggregateType );
	}
}
