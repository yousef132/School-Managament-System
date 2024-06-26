namespace SchoolManagment.Core.Bases
{
	public class ResponseHandler
	{
		public ResponseHandler()
		{

		}

		public Response<T> Deleted<T>(string message)
		{
			return new Response<T>
			{
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = "Deleted Successfuly"

			};
		}
		public Response<T> Success<T>(T entity, object meta = null)
		{
			return new Response<T>
			{
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = "Done Successfuly",
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
				Message = "Created",
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
