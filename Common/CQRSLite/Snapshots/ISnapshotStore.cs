using System;


namespace Common.CQRSlite.Snapshots
{
	public interface ISnapshotStore
	{
		Snapshot Get( Guid id );
		void Save( Snapshot snapshot );
	}
}
