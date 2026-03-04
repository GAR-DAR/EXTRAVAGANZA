using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreatePostDTO
{

    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Content { get; set; } = string.Empty;

    [Required]
    public string PictureUrl { get; set; } = string.Empty;
    [Required]
    public string Type { get; set; } = string.Empty;
    [Required]
    public string Author { get; set; } = string.Empty;


    //if i work with numbers i can write [Range(1, int.MaxValue, ErrorMessage = "The field {0} must be greater than 0.")]
}
