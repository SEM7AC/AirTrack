using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirTrack.Server.Models.People;

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

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";

    public Instructor Clone() =>
        new Instructor
            {
            Id = Id,
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Phone = Phone,
            Certifications = Certifications,
            HireDate = HireDate,
            Status = Status
            };

    public static Instructor CreateNew() =>
        new Instructor
            {
            HireDate = DateTime.Now,
            Status = PersonStatus.Active
            };

    public void ApplyNormalization()
        {
        FirstName = FirstName.Trim();
        LastName = LastName.Trim();
        Email = Email.Trim();
        Phone = Phone.Trim();
        Certifications = Certifications.Trim();
        }

    public bool MatchesSearch(string? text)
        {
        if (string.IsNullOrWhiteSpace(text))
            return true;

        return
            FirstName.Contains(text, StringComparison.OrdinalIgnoreCase) ||
            LastName.Contains(text, StringComparison.OrdinalIgnoreCase) ||
            Email.Contains(text, StringComparison.OrdinalIgnoreCase);
        }

    }

