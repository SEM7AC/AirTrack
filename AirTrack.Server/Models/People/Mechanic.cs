using System.ComponentModel.DataAnnotations;

namespace AirTrack.Server.Models.People;

public class Mechanic
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

    [Required]
    public string CertificationNumber { get; set; } = string.Empty;

    public DateTime HireDate { get; set; } = DateTime.Now;

    public PersonStatus Status { get; set; } = PersonStatus.Active;

    //Logic moved from razor page

    public void ApplyNormalization()
        {
        FirstName = FirstName?.Trim() ?? string.Empty;
        LastName = LastName?.Trim() ?? string.Empty;
        NormalizeEmail();
        NormalizePhone();
        CertificationNumber = CertificationNumber?.Trim() ?? string.Empty;
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
            || Email.Contains(search, StringComparison.OrdinalIgnoreCase)
            || CertificationNumber.Contains(search, StringComparison.OrdinalIgnoreCase);
        }

    public Mechanic Clone()
        {
        return new Mechanic
            {
            Id = this.Id,
            FirstName = this.FirstName,
            LastName = this.LastName,
            Email = this.Email,
            Phone = this.Phone,
            CertificationNumber = this.CertificationNumber,
            HireDate = this.HireDate,
            Status = this.Status
            };
        }

    public static Mechanic CreateNew()
        {
        return new Mechanic
            {
            HireDate = DateTime.Now,
            Status = PersonStatus.Active
            };
        }

    }

