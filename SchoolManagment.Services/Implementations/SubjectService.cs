﻿using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Data.Responses;
using SchoolManagment.Infrastructure.Abstracts;
using SchoolManagment.Services.Abstracts;
using Serilog;

namespace SchoolManagment.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository subjectRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IInstructorRepository instructorRepository;

        public SubjectService(ISubjectRepository subjectRepository,
                              IDepartmentRepository departmentRepository,
                              IInstructorRepository instructorRepository)
        {
            this.subjectRepository = subjectRepository;
            this.departmentRepository = departmentRepository;
            this.instructorRepository = instructorRepository;
        }

        public async Task<bool> AddSubject(Subject subject)
        {
            try
            {
                await subjectRepository.AddAsync(subject);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error("Failed To Create Subject");
                return false;
            }
        }

        public async Task<bool> IsSubjectExist(int id)
            => await subjectRepository.GetTableAsNotTracked().AnyAsync(s => s.SubId == id);

        public async Task<Subject?> GetSubjectById(int id)
            => await subjectRepository.GetTableAsNotTracked().FirstOrDefaultAsync(s => s.SubId == id);

        public async Task<bool> DeleteSubject(Subject subject)
        {
            try
            {
                await subjectRepository.DeleteAsync(subject);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error("Failed To Delete Subject");
                return false;
            }

        }

        public async Task<bool> EditSubject(Subject subject)
        {
            try
            {
                await subjectRepository.UpdateAsync(subject);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error("Failed To Update Subject");
                return false;
            }
        }

        public async Task<bool> AddSubjectToDepartment(int subjectId, int departmentId)
        {
            try
            {
                // get subject and check for null
                // got it as tracked to add the 'DepartmentSubject' object to it's list later
                var subject = subjectRepository.GetTableAsTracked().FirstOrDefault(s => s.SubId == subjectId);
                if (subject == null)
                    return false;
                // get department and check for null

                var department = departmentRepository.GetTableAsNotTracked().FirstOrDefault(s => s.DeptId == subjectId);
                if (department == null)
                    return false;

                var departmentSubject = new DepartmentSubject(departmentId, subjectId);
                subject.DepartmentSubjects.Add(departmentSubject);

                await subjectRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return false;
                throw;
            }
        }

        public async Task<bool> AddInstructorToSubject(int subjectId, int instructorId)
        {
            try
            {
                // get subject and check for null
                // got it as tracked to add the 'DepartmentSubject' object to it's list later
                var subject = subjectRepository.GetTableAsTracked().FirstOrDefault(s => s.SubId == subjectId);
                if (subject == null)
                    return false;

                var instructor = await instructorRepository.GetTableAsNotTracked().FirstOrDefaultAsync(i => i.InstId == instructorId);
                if (instructor == null)
                    return false;

                var subjectInstructor = new SubjectInsturctor(subjectId, instructorId);
                subject.SubjectInstructors.Add(subjectInstructor);
                await subjectRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return false;
                throw;
            }
        }

        public async Task<IReadOnlyList<Subject>> GetAllSubjectsIncludingDepartments()
            => await subjectRepository.GetTableAsNotTracked().Include(s => s.DepartmentSubjects).ThenInclude(ds => ds.Department).ToListAsync();

        public async Task<IReadOnlyList<GetNumberOfStudentsForSubjectResponse>> GetNumberOfStudentsForSubjects()
            => await subjectRepository.GetTableAsNotTracked()
                                 .Include(s => s.StudentSubjects)
                                 .Select(s => new GetNumberOfStudentsForSubjectResponse
                                 {
                                     SubjectId = s.SubId,
                                     SubjectName = s.Localize(s.SubjectNameAr, s.SubjectNameEn),
                                     NumberOfStudents = s.StudentSubjects.Count
                                 })
                                 .ToListAsync();

        public async Task<IReadOnlyList<GetTopStudentInEachSubjectResponse>> GetTopStudentInEachSubject()
        {
            var result = await subjectRepository.GetTableAsNotTracked()
                                  .Include(s => s.StudentSubjects)
                                  .ThenInclude(ss => ss.Student)
                                  .Select(s => new
                                  {
                                      Subject = s,
                                      TopStudent = s.StudentSubjects
                                          .OrderByDescending(ss => ss.Grade)
                                          .FirstOrDefault(),

                                  }).ToListAsync();


            return result.Select(x => new GetTopStudentInEachSubjectResponse
            {
                SubjectId = x.Subject.SubId,
                SubjectName = x.Subject.Localize(x?.Subject?.SubjectNameAr ?? "", x?.Subject?.SubjectNameEn ?? ""),
                StudentId = x.TopStudent?.StudId ?? null,
                StudentName = x.TopStudent?.Student?.Localize(x?.TopStudent?.Student?.NameAr ?? null, x?.TopStudent?.Student?.NameEn ?? null) ?? null,
                Grade = x?.TopStudent?.Grade ?? null

            }).ToList();

        }
    }
}