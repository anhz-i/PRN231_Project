using System;
using System.Collections.Generic;

namespace BussinessObjects.Models;

public partial class Folder
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? Description { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<FolderDetail> FolderDetails { get; set; } = new List<FolderDetail>();
}
