using System;
using System.Collections.Generic;

namespace BussinessObjects.Models;

public partial class ClassSet
{
    public DateTime? UpdateDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long ClassId { get; set; }

    public long SetId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual StudySet Set { get; set; } = null!;
}
