using RazorPokedex.Data;

namespace RazorPokedex.Utils;

public class DbUtils
{
    private readonly Context _context;

    public DbUtils(Context context)
    {
        _context = context;
    }

    public void CheckDbExist()
    {
        string path = Environment.CurrentDirectory.ToString() + "/Inventory.db";

        if (!System.IO.File.Exists(path))
            _context.Database.EnsureCreated();
    }
}
