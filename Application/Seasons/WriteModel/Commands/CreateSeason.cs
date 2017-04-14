using System;
using Common.CQRSlite.Commands;

namespace Application.Seasons.WriteModel.Commands
{
	public class CreateSeason : ICommand
	{
		public readonly string Year;

		public CreateSeason( Guid id, string year )
		{
			Id = id;
			Year = year;
		}

		public Guid Id { get; set; }
		public int ExpectedVersion { get; set; }
	}
}
