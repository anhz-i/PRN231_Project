using System;
using System.Collections.Generic;

namespace BussinessObjects.Models;

public partial class ChatGpt
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public string Question { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public int Count { get; set; }

    public bool? IsImportant { get; set; }

    public virtual User? User { get; set; }
}
