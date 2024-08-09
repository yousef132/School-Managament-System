using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Data.Entities
{
    public class SubjectInsturctor
    {
        public SubjectInsturctor(int subId, int insId)
        {
            SubId = subId;
            InsId = insId;
        }

        public int SubId { get; set; }
        public int InsId { get; set; }


        [ForeignKey("InsId")]
        [InverseProperty(nameof(Instructor.SubjectInsturctors))]

        public Instructor Instructor { get; set; }
        [ForeignKey("SubId")]
        [InverseProperty(nameof(Subject.SubjectInstructors))]
        public Subject Subject { get; set; }


    }
}
