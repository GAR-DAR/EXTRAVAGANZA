using System;

namespace Core.Entities;

public class Post : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public required string PictureUrl { get; set; }


    public required string Type { get; set; }
    public required string Author { get; set; }
}
