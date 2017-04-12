using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Application.Seasons.Commands.CreateSeason.Factory
{
	[ExcludeFromCodeCoverage]
	[TestClass]
	public class SeasonFactoryTests
	{
		#region  Initialisation and setup

		private SeasonFactory _cut;

		private const string Year = "2016";

		[TestInitialize]
		public void TestInitialize()
		{
			_cut = new SeasonFactory();
		}


		[TestCleanup]
		public void TearDown()
		{
		}

		#endregion

		[TestMethod]
		public void TestCreateShouldCreateSeason()
		{
			var result = _cut.Create( Year );

			Assert.AreEqual( result.Year, Year );
		}
	}
}
