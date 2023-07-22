using RazorPokedex.Data;

namespace RazorPokedex.Repositories;

public interface IAddOrEditPkmnRepository
{
    void AddOrEditPkmn(PokeDexEntry AddOrEditEntry);
}
