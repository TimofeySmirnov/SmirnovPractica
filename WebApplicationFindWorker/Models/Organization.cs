using System;
using System.Collections.Generic;

namespace WebApplicationFindWorker.Models;

public partial class Organization
{
    public int Id { get; set; }

    public string NameOrganization { get; set; } = null!;

    public string? Description { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? PersonalAccount { get; set; }

    public int IdUserrole { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual UserRole IdUserroleNavigation { get; set; } = null!;

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
