using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagment.Data.Helper;
using SchoolProject.Service.AuthServices.Interfaces;

namespace SchoolManagment.Core.Filters
{
    public class AuthAttribute : Attribute, IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var currentUserService = context.HttpContext.RequestServices.GetRequiredService<ICurrentUserService>();

            if (context?.HttpContext?.User?.Identity?.IsAuthenticated ?? false)
            {
                var roles = await currentUserService.GetCurrentUserRolesAsync();
                if (roles.All(x => x != Roles.Admin))
                    context.Result = new ObjectResult("Forbidden")
                    {
                        StatusCode = StatusCodes.Status403Forbidden,
                    };
                else
                    await next.Invoke();
            }
        }
    }
}
