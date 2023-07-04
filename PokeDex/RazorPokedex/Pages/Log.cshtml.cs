using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPokedex.Data;
using System;

namespace RazorPokedex.Pages;

public class LogModel : PageModel
{
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
