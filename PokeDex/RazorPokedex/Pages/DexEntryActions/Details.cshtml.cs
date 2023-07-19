using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPokedex.Data;

namespace RazorPokedex.Pages.DexEntryActions;

public class DetailsModel : PageModel
{
    private readonly Context _context;
    public PokeDexEntry DexEntry { get; set; } = new PokeDexEntry();

    public string Header { get; set; }

    public DetailsModel(Context context)
    {
        _context = context;
    }

    public async void OnGetAsync(string id)
    {
        DexEntry = await _context.PokeDexEntries.SingleOrDefaultAsync(x => x.Id == id);

        if (DexEntry == null)
        {
            Header = "MissingNo.";
        }
    }
}
