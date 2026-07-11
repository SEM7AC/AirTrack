using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirTrack.Server.Models.People;

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

    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
    ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = string.Empty;


    [Phone]
    public string Phone { get; set; } = string.Empty;

    public DateTime EnrollmentDate { get; set; } = DateTime.Now;

    public PersonStatus Status { get; set; } = PersonStatus.Active;

    public int? AssignedInstructorId { get; set; }
    public Instructor? AssignedInstructor { get; set; }

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";

    // Removed Logic from Razor page
    public void ApplyNormalization()
        {
        FirstName = FirstName?.Trim() ?? string.Empty;
        LastName = LastName?.Trim() ?? string.Empty;
        NormalizeEmail();
        NormalizePhone();
        }

    
    public void NormalizeEmail()
        {
        if (!string.IsNullOrWhiteSpace(Email))
            Email = Email.Trim().ToLowerInvariant();
        }

    public void NormalizePhone()
        {
        if (!string.IsNullOrWhiteSpace(Phone))
            Phone = Phone.Trim();
        }

    public bool MatchesSearch(string search)
        {
        if (string.IsNullOrWhiteSpace(search))
            return true;

        return FirstName.Contains(search, StringComparison.OrdinalIgnoreCase)
            || LastName.Contains(search, StringComparison.OrdinalIgnoreCase)
            || Email.Contains(search, StringComparison.OrdinalIgnoreCase);
        }
    public Student Clone()
        {
        return new Student
            {
            Id = this.Id,
            FirstName = this.FirstName,
            LastName = this.LastName,
            Email = this.Email,
            Phone = this.Phone,
            EnrollmentDate = this.EnrollmentDate,
            Status = this.Status,
            AssignedInstructorId = this.AssignedInstructorId
            };
        }

    public static Student CreateNew()
        {
        return new Student
            {
            EnrollmentDate = DateTime.Now,
            Status = PersonStatus.Active
            };
        }


    }

