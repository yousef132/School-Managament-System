using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Resources;

namespace SchoolManagment.Core.Bases
{
	public class ResponseHandler
	{
		private readonly IStringLocalizer<SharedResource> stringLocalizer;

		public ResponseHandler(IStringLocalizer<SharedResource> stringLocalizer)
		{
			this.stringLocalizer = stringLocalizer;
		}

		public Response<T> Deleted<T>(string message)
		{
			return new Response<T>
			{
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = stringLocalizer[SharedResourcesKeys.Deleted]

			};
		}
		public Response<T> Success<T>(T entity, object meta = null)
		{
			return new Response<T>
			{
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = stringLocalizer[SharedResourcesKeys.Success],
				Data = entity,
				Meta = meta
			};
		}
		public Response<T> Unauthorized<T>()
		{
			return new Response<T>
			{
				StatusCode = System.Net.HttpStatusCode.Unauthorized,
				Succeeded = false,
				Message = "Unauthorized",
			};
		}
		public Response<T> BadRequest<T>(string message = null)
		{
			return new Response<T>
			{
				StatusCode = System.Net.HttpStatusCode.BadRequest,
				Succeeded = false,
				Message = message == null ? "Bad Request" : message
			};
		}

		public Response<T> NotFound<T>(string message = null)
		{
			return new Response<T>
			{
				StatusCode = System.Net.HttpStatusCode.NotFound,
				Succeeded = false,
				Message = message == null ? "Not Found" : message
			};
		}

		public Response<T> Created<T>(object meta = null)
		{
			return new Response<T>
			{
				StatusCode = System.Net.HttpStatusCode.Created,
				Succeeded = true,
				Message = stringLocalizer[SharedResourcesKeys.Created],
				Meta = meta
			};
		}

		public Response<T> UnprocessableEntity<T>(string message = null)
		{
			return new Response<T>
			{
				StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
				Succeeded = false,
				Message = message == null ? "Unprocessable Entity" : message
			};
		}
	}
}
