using System;
using System.Collections.Generic;

namespace BussinessObjects.Models;

public partial class UserFlashCard
{
    public long UserId { get; set; }

    public long FlashCardId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool? IsImportant { get; set; }

    public bool? IsStudied { get; set; }

    public bool? IsRemembered { get; set; }

    public virtual FlashCard FlashCard { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
