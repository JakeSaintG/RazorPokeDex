using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPokedex.Data;

public class PokeDexEntry
{
    [Key]
    public String Id { get; set; }
    public string? Name { get; set; }
    public string? Type1 { get; set; }
    public string? Type2 { get; set; }
    public int Height { get; set; } //TODO: In centimeteres or inches?
    public int Weight { get; set; } //TODO: In centimeteres or inches?
    public string? ImageURL { get; set; }
    public bool IsHomebrew { get; set; } 
    public string? Category { get; set; }
    public string? FlavorTXT { get; set; }
}
