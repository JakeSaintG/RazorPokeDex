using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPokedex.Data;

namespace RazorPokedex.Pages;

public class AddOrEditPkmnModel : PageModel
{

    public string PageHeader { get; set; } = "Add to PokéDex.";
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
            AddOrEditEntry = _context.PokeDexEntries.FromSql($"SELECT * FROM PokeDexEntries WHERE Id = {id} LIMIT 1").Single();
            PageHeader = $"Edit Dex Entry:{AddOrEditEntry.Name}";
        }
    }

    //IActionResult allows Razor to redirect to a page at the end of execution
    public IActionResult OnPost()
    {

        if (AddOrEditEntry.Id == null)
        {
            AddOrEditEntry.Id = Guid.NewGuid().ToString();
            AddOrEditEntry.IsHomebrew = true;

            //TODO: Placeholder; hardcoded for now
            AddOrEditEntry.ImageURL = "https://www.serebii.net/pokearth/sprites/rb/000.png";

            _context.PokeDexEntries.Add(AddOrEditEntry);
        }
        else
        {
            var editedEntry = _context.PokeDexEntries.FromSql($"SELECT * FROM PokeDexEntries WHERE Id = {AddOrEditEntry.Id} LIMIT 1").Single();

            //TODO: Temporary. Merge these objs.
            if (editedEntry.Name != AddOrEditEntry.Name)
                editedEntry.Name = AddOrEditEntry.Name;

            if (editedEntry.Type1 != AddOrEditEntry.Type1)
                editedEntry.Type1 = AddOrEditEntry.Type1;

            if (editedEntry.Type2 != AddOrEditEntry.Type2)
                editedEntry.Type2 = AddOrEditEntry.Type2;

            if (editedEntry.Height != AddOrEditEntry.Height)
                editedEntry.Height = AddOrEditEntry.Height;

            if (editedEntry.Weight != AddOrEditEntry.Weight)
                editedEntry.Weight = AddOrEditEntry.Weight;

            if (editedEntry.Category != AddOrEditEntry.Category)
                editedEntry.Category = AddOrEditEntry.Category;

            if (editedEntry.FlavorTXT != AddOrEditEntry.FlavorTXT)
                editedEntry.FlavorTXT = AddOrEditEntry.FlavorTXT;
        }

        _context.SaveChanges();

        return RedirectToPage("./Log");
    }
}
