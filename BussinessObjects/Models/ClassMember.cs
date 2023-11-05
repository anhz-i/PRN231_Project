using System;
using System.Collections.Generic;

namespace BussinessObjects.Models;

public partial class ClassMember
{
    public DateTime? UpdateDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long ClassId { get; set; }

    public long MemberId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual User Member { get; set; } = null!;
}
