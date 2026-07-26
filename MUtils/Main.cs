// Rand() Headers
using Kernel;

// C# Headers
using System;

class Main
{

    /*
     * The logo variable contains the ASCII art representation of the program's logo.
     * It is displayed at the top of the menu when the DisplayMenu method is called.
     */
    static string logo = @" /$$      /$$ /$$   /$$   /$$     /$$ /$$          
| $$$    /$$$| $$  | $$  | $$    |__/| $$          
| $$$$  /$$$$| $$  | $$ /$$$$$$   /$$| $$  /$$$$$$$
| $$ $$/$$ $$| $$  | $$|_  $$_/  | $$| $$ /$$_____/
| $$  $$$| $$| $$  | $$  | $$    | $$| $$|  $$$$$$ 
| $$\  $ | $$| $$  | $$  | $$ /$$| $$| $$ \____  $$
| $$ \/  | $$|  $$$$$$/  |  $$$$/| $$| $$ /$$$$$$$/
|__/     |__/ \______/    \___/  |__/|__/|_______/ 
                                                   
                                                   
                                                   ";

    /*
     * Function info
     * - Displays the main menu of the program, including the logo and build information.
     * 
     * Usage
     * - Call function directly
     */
    public static void DisplayMenu()
    {
        Kernel.Out.cls();

        Kernel.Out.printf(logo);

        Kernel.Out.separator();

        Kernel.Build.displayBuildInfo();

        Kernel.UserPrompt.multKeysf(new List<(string Message, Action? FuncName, ConsoleKey Key)>
        {
            ("Maths", Navigation.NMaths, ConsoleKey.D1),
            ("Sciences", Navigation.NSciences, ConsoleKey.D2),
            ("Exit", Termination.Terminate, ConsoleKey.D0)
        }, "Main Menu");
    }
}

class Navigation
{
    public static void NMaths()
    {
        Kernel.Out.cls();

        Kernel.UserPrompt.multKeysf(new List<(string Message, Action? FuncName, ConsoleKey Key)>
        {
            ("Percentages", Percentages.Nav, ConsoleKey.D1),
            ("Overtime Pay", OvertimePay.Nav, ConsoleKey.D2),
            ("Income Deductions", IncomeDeductions.Nav, ConsoleKey.D3),
            ("Back to Main Menu", Main.DisplayMenu, ConsoleKey.D0)
        }, "Maths");
    }

    public static void NSciences()
    {
        Kernel.Out.cls();
        Kernel.UserPrompt.multKeysf(new List<(string Message, Action? FuncName, ConsoleKey Key)>
        {
            ("Back to Main Menu", Main.DisplayMenu, ConsoleKey.D0)
        }, "Sciences");
    }
}

class Termination
{
    static string terminatedIcon = @"             /$$$
            /$$_/
 /$$   /$$ /$$/  
|  $$ /$$/| $$   
 \  $$$$/ | $$   
  >$$  $$ |  $$  
 /$$/\  $$ \  $$$
|__/  \__/  \___/
                 
                 
                 ";

    public static void Terminate()
    {
        Kernel.Out.cls();

        Kernel.Out.printf(terminatedIcon);

        Kernel.Out.printa($"Thank you for using {Kernel.Build.name}!");

        Kernel.Out.separator();

        Environment.Exit(0);
    }
}