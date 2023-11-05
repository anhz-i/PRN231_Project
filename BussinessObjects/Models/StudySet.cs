using System;
using System.Collections.Generic;

namespace BussinessObjects.Models;

public partial class StudySet
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ClassSet> ClassSets { get; set; } = new List<ClassSet>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<FlashCard> FlashCards { get; set; } = new List<FlashCard>();

    public virtual ICollection<FolderDetail> FolderDetails { get; set; } = new List<FolderDetail>();

    public virtual ICollection<UserStudySet> UserStudySets { get; set; } = new List<UserStudySet>();
}
