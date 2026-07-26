// Rand() Headers
using Kernel;

// C# Headers
using System;

class Percentages
{
    public static void Nav()
    {
        Kernel.Out.cls();
        Kernel.UserPrompt.multKeysf(new List<(string Message, Action? FuncName, ConsoleKey Key)>
        {
            ("Original Price Finder", OriginalPriceFinder, ConsoleKey.D1),
            ("Percentage Increase", PercentageIncrease, ConsoleKey.D2),
            ("Percentage Decrease", PercentageDecrease, ConsoleKey.D3),
            ("Back", Navigation.NMaths, ConsoleKey.D0)
        }, "Percentages");
    }

    public static void OriginalPriceFinder()
    {
        Kernel.Out.cls();

        Kernel.UserPrompt.submenu(OriginalPriceFinder, Nav, "Original Price Finder");
    }

    public static void PercentageIncrease()
    {
        Kernel.Out.cls();

        Kernel.UserPrompt.submenu(PercentageIncrease, Nav, "Percentage Increase");
    }

    public static void PercentageDecrease()
    {
        Kernel.Out.cls();

        Kernel.UserPrompt.submenu(PercentageDecrease, Nav, "Percentage Decrease");
    }
}
