using Domain.Common;

namespace Domain.Seasons
{
	public class Season : IEntity
	{
		public int Id { get; set; }

		public string Year { get; set; }
	}
}
