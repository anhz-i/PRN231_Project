using System;
using System.Collections.Generic;

namespace BussinessObjects.Models;

public partial class UserStudySet
{
    public long UserId { get; set; }

    public long SetId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? IsFavorite { get; set; }

    public virtual StudySet Set { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
