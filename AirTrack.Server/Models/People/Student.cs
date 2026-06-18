using System.ComponentModel.DataAnnotations;

namespace AirTrack.Server.Models.People
    {
    public class Student
        {
        public int Id { get; set; }

        private string _firstName = string.Empty;

        [Required]
        public string FirstName
            {
            get => _firstName;
            set => _firstName = value.Trim();
            }

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string Phone { get; set; } = string.Empty;

        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        public PersonStatus Status { get; set; } = PersonStatus.Active;

        public int? AssignedInstructorId { get; set; }
        public Instructor? AssignedInstructor { get; set; }
        }
    }
