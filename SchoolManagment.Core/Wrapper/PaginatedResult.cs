namespace SchoolManagment.Core.Wrapper
{
	public class PaginatedResult<T>
	{
		private readonly List<T> data;

		public PaginatedResult(List<T> data)
		{
			this.data = data;
		}

	}
}
