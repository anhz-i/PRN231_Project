using System;
using System.Collections.Generic;

namespace BussinessObjects.Models;

public partial class FlashCard
{
    public long Id { get; set; }

    public long? SetsId { get; set; }

    public string Question { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool? IsImportant { get; set; }

    public virtual StudySet? Sets { get; set; }

    public virtual ICollection<UserFlashCard> UserFlashCards { get; set; } = new List<UserFlashCard>();
}
