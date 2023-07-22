using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPokedex.Data;
using RazorPokedex.Repositories;
using System.Text.RegularExpressions;

namespace RazorPokedex.Pages;

public class AddOrEditPkmnModel : PageModel
{

    public string PageHeader { get; set; } = "Add to PokéDex.";
    public List<string> Types { get; } = new List<string>(){ 
        "Normal", 
        "Fire", 
        "Water", 
        "Grass",
        "Electric",
        "Ice",
        "Fighting",
        "Poison",
        "Ground",
        "Flying",
        "Psychic",
        "Bug",
        "Rock",
        "Ghost",
        "Dark",
        "Dragon",
        "Steel",
        "Fairy"
    };
    private readonly Context _context;
    private IAddOrEditPkmnRepository _addOrEditPkmnRepository;

    [BindProperty]
    public PokeDexEntry? AddOrEditEntry { get; set; }

    public AddOrEditPkmnModel(Context context, IAddOrEditPkmnRepository addOrEditPkmnRepository)
    {
        _context = context;
        _addOrEditPkmnRepository = addOrEditPkmnRepository;
    }

    public void OnGetAsync(string id)
    {
        if (id != null)
        {
            AddOrEditEntry = _context.PokeDexEntries.FromSql($"SELECT * FROM PokeDexEntries WHERE Id = {id} LIMIT 1").Single();
            PageHeader = $"Edit Dex Entry: {AddOrEditEntry.Name}";
        }
    }

    //IActionResult allows Razor to redirect to a page at the end of execution
    public async Task<IActionResult> OnPostAsync()
    {
        _addOrEditPkmnRepository.AddOrEditPkmn(AddOrEditEntry);
        return RedirectToPage("./Log");
    }
}
