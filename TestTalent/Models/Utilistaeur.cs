using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTalent.Models;

public partial class Utilistaeur
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    [EmailAddress(ErrorMessage = "Email Address invalide")]
    public string? Email { get; set; }
}
