using System;
using System.Collections.Generic;

namespace WebApplicationFindWorker.Models;

public partial class Post
{
    public int Id { get; set; }

    public string NamePost { get; set; } = null!;

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
