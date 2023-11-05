using System;
using System.Collections.Generic;

namespace BussinessObjects.Models;

public partial class FolderDetail
{
    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public long SetId { get; set; }

    public long FolderId { get; set; }

    public virtual Folder Folder { get; set; } = null!;

    public virtual StudySet Set { get; set; } = null!;
}
