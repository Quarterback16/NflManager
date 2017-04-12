using Application.Interfaces.Persistence;
using Application.Seasons.Commands.CreateSeason.Factory;
using Application.Seasons.Commands.CreateSeason.Repository;

namespace Application.Seasons.Commands.CreateSeason
{
	public class CreateSeasonCommand : ICreateSeasonCommand
	{
		private readonly ISeasonFactory _factory;
		private readonly ISeasonRepositoryFacade _repositories;
		private readonly IUnitOfWork _unitOfWork;

		public CreateSeasonCommand(
			ISeasonFactory factory,
			ISeasonRepositoryFacade repositories,
			IUnitOfWork unitOfWork )
		{
			_factory = factory;
			_repositories = repositories;
			_unitOfWork = unitOfWork;
		}

		public void Execute( CreateSeasonModel model )
		{
			var season = _factory.Create( model.Year );

			_repositories.AddSeason( season );

			_unitOfWork.Save();
		}
	}
}
