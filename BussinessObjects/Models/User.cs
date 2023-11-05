using System;
using System.Collections.Generic;

namespace BussinessObjects.Models;

public partial class User
{
    public long Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Username { get; set; } = null!;

    public virtual ICollection<ChatGpt> ChatGpts { get; set; } = new List<ChatGpt>();

    public virtual ICollection<ClassMember> ClassMembers { get; set; } = new List<ClassMember>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Folder> Folders { get; set; } = new List<Folder>();

    public virtual ICollection<StudySet> StudySets { get; set; } = new List<StudySet>();

    public virtual ICollection<UserFlashCard> UserFlashCards { get; set; } = new List<UserFlashCard>();

    public virtual ICollection<UserStudySet> UserStudySets { get; set; } = new List<UserStudySet>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
