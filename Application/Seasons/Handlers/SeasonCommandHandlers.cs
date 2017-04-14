using Common.CQRSlite.Domain;
using Common.CQRSlite.Commands;
using Application.Seasons.WriteModel.Commands;
using Domain.Seasons;

namespace Application.Seasons.Handlers
{
	public class SeasonCommandHandlers : ICommandHandler<CreateSeason>
	{
		private readonly ISession _session;

		public SeasonCommandHandlers( ISession session )
		{
			_session = session;
		}

		// for each command there will be a handler
		public void Handle( CreateSeason message )
		{
			var item = new Season( message.Id, message.Year );
			_session.Add( item );
			_session.Commit();
		}
	}
}
