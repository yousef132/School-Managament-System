using Microsoft.Extensions.Localization;
using SchoolManagment.Data.Resources;

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
        public Response<T> Success<T>(T? entity, object meta = null)
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
        public Response<T> Unauthorized<T>(string message = null)
        {
            return new Response<T>
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = false,
                Message = message == null ? stringLocalizer[SharedResourcesKeys.UnAuthorized] : message,
            };
        }
        public Response<T> BadRequest<T>(string message = null)
        {
            return new Response<T>
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = message == null ? stringLocalizer[SharedResourcesKeys.BadRequest] : message
            };
        }

        public Response<T> NotFound<T>(string message = null)
        {
            return new Response<T>
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? stringLocalizer[SharedResourcesKeys.NotFound] : message
            };
        }

        public Response<T> Created<T>(T entity, object Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = stringLocalizer[SharedResourcesKeys.Created],
                Meta = Meta
            };
        }

        public Response<T> UnProcessableEntity<T>(string message = null)
        {
            return new Response<T>
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = message == null ? stringLocalizer[SharedResourcesKeys.UnProcessableEntity] : message
            };
        }
    }
}
