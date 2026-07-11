using System;
using System.ComponentModel.DataAnnotations;
using AirTrack.Server.Models.People;

namespace AirTrack.Server.Models.FormModel;

public class StudentFormModel
    {
    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone]
    public string Phone { get; set; } = string.Empty;

    public DateTime EnrollmentDate { get; set; } = DateTime.Now;

    public PersonStatus Status { get; set; } = PersonStatus.Active;

    public int? AssignedInstructorId { get; set; }
    }

