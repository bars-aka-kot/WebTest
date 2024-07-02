using System;
using System.Collections.Generic;

namespace DBProject3.Model;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    public GenderId GenderId { get; set; }
    public virtual Gender Gender { get; set; }
}
