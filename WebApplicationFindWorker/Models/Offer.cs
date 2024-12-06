using System;
using System.Collections.Generic;

namespace WebApplicationFindWorker.Models;

public partial class Offer
{
    public int Id { get; set; }

    public int IdOrganization { get; set; }

    public string? Heading { get; set; }

    public string? Description { get; set; }

    public int? IdUser { get; set; }

    public int IdPost { get; set; }

    public bool? Active { get; set; }

    public virtual Organization IdOrganizationNavigation { get; set; } = null!;

    public virtual Post IdPostNavigation { get; set; } = null!;

    public virtual User? IdUserNavigation { get; set; }
}
