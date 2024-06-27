using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Students.Queries.Responses;

namespace SchoolManagment.Core.Features.Students.Queries.Models
{
	public class GetStudentsWithPaginationQuery : IRequest<Response<PaginatedResult<GetSingleStudentResponse>>>
	{

		public const int MAXPAGESIZE = 20;
		public string? Sort { get; set; }

		public int PageIndex { get; set; } = 1;

		private int pageSize = 6;

		public int PageSize
		{
			get => pageSize;
			set => pageSize = value < MAXPAGESIZE ? value : MAXPAGESIZE;
		}

		private string? search;

		public string? Search
		{
			get => search;
			set => search = value?.Trim().ToLower();
		}
	}


	public class PaginatedResult<T>
	{
		public PaginatedResult(int pageIndex, int pageSize, IReadOnlyList<T> data)
		{
			PageIndex = pageIndex;
			PageSize = pageSize;
			Data = data;
		}
		public int PageIndex { get; set; }
		//public int Count { get; set; }

		public int PageSize { get; set; }

		public IReadOnlyList<T> Data { get; set; }
	}
}
