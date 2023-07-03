using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPokedex.Data;
using System;

namespace RazorPokedex.Pages;

public class LogModel : PageModel
{
    private readonly Context _context;
    public List<PokeDexEntry> DexEntries { get; set; } = new List<PokeDexEntry>();

    [BindProperty]
    public PokeDexEntry NewEntry { get; set; }

    public LogModel(Context context)
    {
        _context = context;
    }

    public void OnGet()
    {
        DexEntries = _context.PokeDexEntries.ToList();
    }

    //IActionResult allows Razor to redirect to a page at the end of execution
    public IActionResult OnPost() 
    {
        //TODO: Investigate if SQLite will let me use GUIDs/UUIDs
        NewEntry.Id = Guid.NewGuid().ToString();
        NewEntry.IsHomebrew = true;
        
        //TODO: Placeholder; hardcoded for now
        NewEntry.ImageURL = "https://archives.bulbagarden.net/media/upload/9/98/Missingno_RB.png";

        _context.PokeDexEntries.Add(NewEntry);
        _context.SaveChanges();

        return RedirectToPage();
    }
}
