using System.ComponentModel.DataAnnotations;

namespace XmLesson12_Lab6.Models
{
    public class Learner
    {
        public Learner()
        {
            Enrollments = new HashSet<Enrollment>();
        }
        public int LearnerID { get; set; }
        [Required(ErrorMessage = "Please enter a last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a first and middle name.")]
        [Display(Name = "First and Middle Name")]
        public string FirstMidName { get; set; } = string.Empty;
        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }
        [Display(Name = "Major")]
        public int MajorID { get; set; }
        public virtual Major? Major { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
