using WarConflict.Soldiers;

namespace WarConflict;
using static Console;

public static class Helper
{
  
    public static void ClearConsole()
    {
        Clear();
        WriteLine("\x1b[3J");
    }
    
}