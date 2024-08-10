using AutoMapper;

namespace SchoolManagment.Core.Mapping.Subject
{
    public partial class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            AddSubjectCommandMapping();
            EditSubjectCommandMapping();
            GetSubjectWithDepartmentMapping();
        }
    }
}
