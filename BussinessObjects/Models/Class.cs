using System;
using System.Collections.Generic;

namespace BussinessObjects.Models;

public partial class Class
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ClassMember> ClassMembers { get; set; } = new List<ClassMember>();

    public virtual ICollection<ClassSet> ClassSets { get; set; } = new List<ClassSet>();

    public virtual User? CreatedByNavigation { get; set; }
}
