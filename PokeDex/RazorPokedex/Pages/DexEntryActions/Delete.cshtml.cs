using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPokedex.Data;

namespace RazorPokedex.Pages.DexEntryActions;

public class DeleteModel : PageModel
{
    private readonly Context _context;
    public PokeDexEntry DexEntry { get; set; } = new PokeDexEntry();

    public DeleteModel()
    {
        _context = new Context();
    }

    public async void OnGetAsync(string id) => DexEntry = await _context.PokeDexEntries.SingleOrDefaultAsync(x => x.Id == id);

    public async Task<IActionResult> OnPostDeleteAsync(string id)
    {
        PokeDexEntry? entryToDelete = await _context.PokeDexEntries.SingleOrDefaultAsync(d => d.Id == id);

        if (entryToDelete != null)
            _context.PokeDexEntries.Remove(entryToDelete);

        await _context.SaveChangesAsync();
        return RedirectToPage("../Log");
    }
}
