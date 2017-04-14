using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using Moq;
using Application.Interfaces.Persistence;
using Domain.Seasons;
using System.Collections.Generic;
using System.Linq;

namespace Application.Seasons.Queries.GetSeasonList
{
	[ExcludeFromCodeCoverage]
	[TestClass]
	public class GetSeasonListQueryTests
	{
		#region Initialisation and setup

		private GetSeasonListQuery _cut;

		private List<Season> _seasons;
		private Season _season;

		private const int Id = 1;
		private const string Year = "2016";

		// Moq privates
		private Mock<ISeasonRepository> _mockRepository;

		[TestInitialize]
		public void TestInitialize()
		{
			// mock data
			_season = new Season(new Guid(), Year );
			_seasons = new List<Season>(){ _season	};

			// instantiate moqs
			_mockRepository = new Mock<ISeasonRepository>();
			_mockRepository.Setup( m => m.GetAll() ).Returns( _seasons.AsQueryable() );

			// instantiate class under test
			_cut = new GetSeasonListQuery( _mockRepository.Object );
		}

		[TestCleanup]
		public void TearDown()
		{
		}

		#endregion Initialisation and setup

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void GetSeasonListQuery_Constructor_NullRepository()
		{
			var cut = new GetSeasonListQuery(
				  repository: null

			);
			Assert.IsNotNull( cut );
		}

		[TestMethod]
		public void TestExecuteShouldReturnListOfSeasons()
		{
			var results = _cut.Execute();

			var result = results.Single();

			Assert.AreEqual( result.Id, Id );
			Assert.AreEqual( result.Year, Year );
		}
	}
}