using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Students.Queries.Responses;
using SchoolManagment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Core.Features.Students.Queries.Models
{
	public class GetStudentByIdQuery:IRequest<Response<GetSingleStudentResponse>>
	{
        public GetStudentByIdQuery(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }	
	}
}
