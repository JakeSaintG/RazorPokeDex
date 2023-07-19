using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPokedex.Data;

namespace RazorPokedex.Pages;

public class AddOrEditPkmnModel : PageModel
{

    private readonly Context _context;

    [BindProperty]
    public PokeDexEntry? AddOrEditEntry { get; set; }

    public AddOrEditPkmnModel(Context context)
    {
        _context = context;
    }

    public async void OnGetAsync(string id)
    {
        if (id != null)
        {
            Console.WriteLine("");
            AddOrEditEntry = _context.PokeDexEntries.FromSql($"SELECT * FROM PokeDexEntries WHERE Id = {id} LIMIT 1").Single();
        }
    }

    //IActionResult allows Razor to redirect to a page at the end of execution
    public IActionResult OnPost()
    {
        //TODO: Investigate if SQLite will let me use GUIDs/UUIDs
        AddOrEditEntry.Id = Guid.NewGuid().ToString();
        AddOrEditEntry.IsHomebrew = true;

        //TODO: Placeholder; hardcoded for now
        AddOrEditEntry.ImageURL = "https://www.serebii.net/pokearth/sprites/rb/000.png";

        _context.PokeDexEntries.Add(AddOrEditEntry);
        _context.SaveChanges();

        return RedirectToPage("./Log");
    }
}
