using System;
using System.Collections.Generic;

namespace WebApplicationFindWorker.Models;

public partial class UserRole
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
