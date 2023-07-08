using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPokedex.Data;
using System;

namespace RazorPokedex.Pages;

public class LogModel : PageModel
{
    //Testing how to get a string to display from class
    public string Header { get; set; } = "Logged Pok�Dex Entries";

    private readonly Context _context;
    public List<PokeDexEntry> DexEntries { get; set; } = new List<PokeDexEntry>();

    public LogModel(Context context)
    {
        _context = context;
    }

    public void OnGet()
    {
        DexEntries = _context.PokeDexEntries.ToList();
    }
}
