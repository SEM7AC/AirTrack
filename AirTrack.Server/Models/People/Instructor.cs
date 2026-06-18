using System.ComponentModel.DataAnnotations;

namespace AirTrack.Server.Models.People
    {
    public class Instructor
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

        public string Certifications { get; set; } = string.Empty;

        public DateTime HireDate { get; set; } = DateTime.Now;

        public PersonStatus Status { get; set; } = PersonStatus.Active;

        public List<Student> Students { get; set; } = new();
        }
    }
