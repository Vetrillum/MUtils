// Rand() Headers
using Kernel;

// C# Headers
using System;

class OvertimePay
{
    public static void Nav()
    {
        Kernel.Out.cls();
        Kernel.UserPrompt.multKeysf(new List<(string Message, Action? FuncName, ConsoleKey Key)>
        {
            ("Gross Income For Day", GrossIncomeForDay, ConsoleKey.D1),
            ("Overtime Pay For Day", OvertimePayForDay, ConsoleKey.D2),
            ("Back", Navigation.NMaths, ConsoleKey.D0)
        }, "Overtime Pay");
    }

    public static void GrossIncomeForDay()
    {
        Kernel.Out.cls();

        Kernel.UserPrompt.submenu(GrossIncomeForDay, Nav, "Gross Income For Day");

    }

    public static void OvertimePayForDay()
    {
        Kernel.Out.cls();

        Kernel.UserPrompt.submenu(OvertimePayForDay, Nav, "Overtime Pay For Day");
    }
}