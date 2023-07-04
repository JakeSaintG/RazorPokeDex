using RazorPokedex.Data;

namespace RazorPokedex.Utils;

public class DbUtils : IDbUtils
{
    private readonly Context _context;

    public DbUtils(Context context)
    {
        _context = context;
    }

    public void CheckDbExist()
    {
        string path = Directory.GetParent(Environment.CurrentDirectory.ToString()) + "\\RazorPokedex.Data\\Pokedex.db";

        if (!File.Exists(path))
            _context.Database.EnsureCreated();
    }
}
