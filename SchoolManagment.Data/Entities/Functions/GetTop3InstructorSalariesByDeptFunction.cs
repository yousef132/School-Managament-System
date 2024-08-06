﻿using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Common;

namespace SchoolManagment.Data.Entities.Functions
{
    [Keyless]
    public class GetTop3InstructorSalariesByDept : GenerateLocalizableEntity
    {
        public int DepartmentId { get; set; }
        public string DepartmentNameEn { get; set; }
        public string DepartmentNameAr { get; set; }
        public int InstructorId { get; set; }
        public string InstructorNameEn { get; set; }
        public string InstructorNameAr { get; set; }
        public decimal Salary { get; set; }
        public int rn { get; set; }
    }
}
