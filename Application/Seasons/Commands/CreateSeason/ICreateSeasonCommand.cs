namespace Application.Seasons.Commands.CreateSeason
{
	public interface ICreateSeasonCommand
	{
		void Execute( CreateSeasonModel model );
	}
}
