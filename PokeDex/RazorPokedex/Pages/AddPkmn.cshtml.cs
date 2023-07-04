using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPokedex.Data;

namespace RazorPokedex.Pages;

public class AddPkmnModel : PageModel
{

    private readonly Context _context;

    [BindProperty]
    public PokeDexEntry NewEntry { get; set; }

    public AddPkmnModel(Context context)
    {
        _context = context;
    }

    public void OnGet()
    {
    }

    //IActionResult allows Razor to redirect to a page at the end of execution
    public IActionResult OnPost()
    {
        //TODO: Investigate if SQLite will let me use GUIDs/UUIDs
        NewEntry.Id = Guid.NewGuid().ToString();
        NewEntry.IsHomebrew = true;

        //TODO: Placeholder; hardcoded for now
        NewEntry.ImageURL = "https://www.serebii.net/pokearth/sprites/rb/000.png";

        _context.PokeDexEntries.Add(NewEntry);
        _context.SaveChanges();

        return RedirectToPage();
    }
}
