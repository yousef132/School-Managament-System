using MediatR;
using SchoolManagment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Core.Features.Students.Queries.Models
{
    // this is the model of the request
    // request				// Response Type
    public class GetStudentsQuery : IRequest<List<Student>>
    {

    }
}
