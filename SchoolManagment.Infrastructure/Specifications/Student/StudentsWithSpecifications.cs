using SchoolManagment.Infrastructure.Specification;

namespace SchoolManagment.Infrastructure.Specifications.Student
{
	public class StudentsWithSpecifications : BaseSpecification<SchoolManagment.Data.Entities.Student>
	{
		public StudentsWithSpecifications(StudentSpecification specs)
			: base(student => (String.IsNullOrEmpty(specs.Search) || student.NameEn.Trim().ToLower().Contains(specs.Search)))
		{
			AddInclude(s => s.Department);

			if (!String.IsNullOrEmpty(specs.Sort))
			{
				switch (specs.Sort)
				{
					case "Address":
						AddOrderBy(x => x.Address);
						break;
					default:
						AddOrderBy(x => x.NameEn);
						break;
				}
			}
			ApplyPgination(specs.PageSize * (specs.PageIndex - 1), specs.PageSize);
		}

		public StudentsWithSpecifications(int id)
			: base(s => s.StudId == id)
		{
			AddInclude(s => s.Department);
		}
	}
}
