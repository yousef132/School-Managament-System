using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Authentication.Queries.Model
{
    public class ConfirmEmailQuery : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public string Code { get; set; }
    }
}
