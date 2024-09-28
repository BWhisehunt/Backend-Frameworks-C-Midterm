using System.ComponentModel.DataAnnotations;

namespace midterm_project.Models;

public class Pet {
    public int PetId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required, Url]
    public string ImgUrl { get; set; }

    [Required]
    public string Type { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string Age { get; set; }

    [Required]
    public string Price { get; set; }
}