using Application.Interfaces.Persistence;
using Domain.Seasons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace Application.Seasons.Commands.CreateSeason.Repository
{
	[ExcludeFromCodeCoverage]
	[TestClass]
	public class SeasonRepositoryFacadeTests
	{
		#region Initialisation and setup

		private SeasonRepositoryFacade _cut;

		private Season _season;

		private Mock<ISeasonRepository> _mockRepository;

		[TestInitialize]
		public void TestInitialize()
		{
			_mockRepository = new Mock<ISeasonRepository>();

			_season = new Season();

			_cut = new SeasonRepositoryFacade(
				 _mockRepository.Object );
		}

		[TestCleanup]
		public void TearDown()
		{
		}

		#endregion Initialisation and setup

		[TestMethod]
		public void TestAddSaleShouldAddSale()
		{
			_cut.AddSeason( _season );

			_mockRepository
				.Verify( p => p.Add( It.IsAny<Season>() ), Times.Once );
		}
	}
}