﻿using System;
using System.Collections.Generic;

namespace BussinessObjects.Models;

public partial class Role
{
    public long Id { get; set; }

    public string RoleName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
