using System;
using System.Collections.Generic;

namespace WpfLibraryFindWorker.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NumberPassport { get; set; } = null!;

    public string SerialPassport { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string Inn { get; set; } = null!;

    public int IdUserrole { get; set; }

    public virtual UserRole IdUserroleNavigation { get; set; } = null!;

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
