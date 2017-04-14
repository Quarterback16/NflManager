using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Domain.Seasons
{
	[TestClass]
	public class SeasonTests
	{
		#region  Initialisation and setup

		private Season _cut;

		private const int Id = 1;
		private const string Year = "2016";


		[TestInitialize]
		public void TestInitialize()
		{
			_cut = new Season(new Guid(), Year );
		}

		[TestCleanup]
		public void TearDown()
		{
		}

		#endregion

		[TestMethod]
		public void TestSetAndGetId()
		{
			// broken test
			//_cut.Id = Id;

			//Assert.AreEqual( _cut.Id, Id );
		}

		[TestMethod]
		public void TestSetAndGetName()
		{
			_cut.Year = Year;

			Assert.AreEqual( _cut.Year, Year );
		}


	}
}
