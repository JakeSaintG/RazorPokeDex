using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorPokedex.Data;

namespace RazorPokedex.Repositories;

public class AddOrEditPkmnRepository : IAddOrEditPkmnRepository
{
    private readonly Context _context;

    public AddOrEditPkmnRepository(Context context)
    {
        _context = context;
    }

    public async void AddOrEditPkmn(PokeDexEntry AddOrEditEntry) 
    {

        if (AddOrEditEntry.Id == null)
        {
            AddPkmn(AddOrEditEntry);
        }
        else
        {
            EditPkmn(AddOrEditEntry);
        }

        await _context.SaveChangesAsync();
    }

    private async void AddPkmn(PokeDexEntry AddOrEditEntry) 
    {
        var addedEntry = AddOrEditEntry;

        addedEntry.Id = Guid.NewGuid().ToString();
        addedEntry.IsHomebrew = true;

        //TODO: Placeholder; hardcoded for now
        addedEntry.ImageURL = "https://www.serebii.net/pokearth/sprites/rb/000.png";

        if (addedEntry.Type1 == addedEntry.Type2)
            addedEntry.Type2 = null;

        await _context.PokeDexEntries.AddAsync(addedEntry);
    }

    private async void EditPkmn(PokeDexEntry AddOrEditEntry) 
    {
        PokeDexEntry editedEntry = _context.PokeDexEntries.FromSql($"SELECT * FROM PokeDexEntries WHERE Id = {AddOrEditEntry.Id} LIMIT 1").Single();

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

        if (editedEntry.Type1 == editedEntry.Type2)
            editedEntry.Type2 = null;
    }
}
