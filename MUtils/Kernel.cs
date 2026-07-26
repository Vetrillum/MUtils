/*
 * 
 *   Veto | Rand()
 * 
 */

using System.Runtime;

namespace Kernel
{
    /*
     * Class info
     * - Set specific build details you may want to display in your program.
     */
    class Build
    {
        /* -- Set values here -- */
        public static string author { get; set; } = "Vetrillum";
        public static string organisation { get; set; } = "Rand()";
        public static string name { get; set; } = "MUtils";
        public static string description { get; set; } = "Doing your Maths for you so you don't have to!!";

        public static int maj { get; set; } = 0;
        public static int min { get; set; } = 1;
        public static int patch { get; set; } = 0;

        /*
         * Function info
         * - Displays application build information. Each detail can be toggled with boolean flags.
         * 
         * Usage
         * - Call function directly
         * - Modify flags as needed
         */
        public static void displayBuildInfo(bool doDesc = true, bool doAuthor = true, bool doOrganisation = true, bool doVersion = true, int width = 50)
        {
            Out.aestheticContainerBegin(name, width, true);

            if (doDesc) { Out.aestheticContainerContent(description, width); }
            Out.aestheticContainerContent("", width);
            Out.aestheticContainerContent($"{(doAuthor ? author : null)} {(doOrganisation ? $"| {organisation}" : null)} {(doVersion ? $"| {maj}.{min}.{patch}" : null)}", width);

            Out.aestheticContainerEnd(width, true);
        }
    }

    /*
     * Class info
     * - A library of functions dedicated to ease gathering user input.
     */
    class UserPrompt
    {

        /*
         * Function info
         * - Prompts the user to press any key then executes the provided function after.
         * - This is an "aesthetic" version of the function. To use a "plain" version, see anyKey().
         * 
         * Usage
         * - Call function directly
         * - Must indicate a function to be called.
         */
        public static void anyKeyf(Action? funcName, string message = "Press any key to continue...")
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n[ {message} ]\n");
            Console.ResetColor();
            Console.ReadKey();
            funcName?.Invoke();
        }

        /*
         * Function info
         * - Prompts the user to press the indicated key then executes the indicated function after.
         * - This is an "aesthetic" version of the function. To use a "plain" version, see singleKey().
         * 
         * Usage
         * - Call function directly
         * - Must indicate a message, a key, and a function to be called.
         */
        public static void singleKeyf(string message, Action? funcName, ConsoleKey key)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n[{key}] {message}\n");
            Console.ResetColor();
            if (key == Console.ReadKey(true).Key) funcName?.Invoke();
        }

        /*
         * Function info
         * - Prompts the user to select from a list of provided options, then executes the respective function after.
         * - Has a default "Navigation" header. Modify as needed.
         * - Has a default width of 50 chars. Modify as needed.
         * - This is an "aesthetic" version of the function. To use a "plain" version, see multKeys().
         * 
         * Usage
         * - Call function directly.
         * - Must indicate a List<>.
         *      - List contains a message, a key, and a function to be called.
         */
        public static void multKeysf(List<(string Message, Action? FuncName, ConsoleKey Key)> prompts, string header = "Navigation", int width = 50)
        {
            Out.aestheticContainerBegin(header, width);

            foreach (var prompt in prompts)
            {
                Out.delay(30);

                string text = $" [{prompt.Key}] {prompt.Message}";
                Out.aestheticContainerContent(text, width);
            }
            Console.ResetColor();

            Out.aestheticContainerEnd(width);

            bool validKeyPressed = false;

            while (!validKeyPressed)
            {

                ConsoleKeyInfo input = Console.ReadKey(true);
                var match = prompts.FirstOrDefault(p => p.Key == input.Key);
                if (match.Key != default)
                {
                    validKeyPressed = true;
                    match.FuncName?.Invoke();
                }
            }
        }

        public static void submenu(Action? FuncRerun, Action? FuncBack, string header = "Submenu", int width = 50)
        {
            multKeysf(new List<(string Message, Action? FuncName, ConsoleKey Key)>
            {
                ("Run Again", FuncRerun, ConsoleKey.D1),
                ("Back", FuncBack, ConsoleKey.D0)
            }, header, width);
        }


        /*
         * Function info
         * - Prompts the user to press any key then executes the provided function after.
         * 
         * Usage
         * - Call function directly
         * - Must indicate a function to be called.
         */
        public static void anyKey(Action? funcName, string message = "Press any key to continue...")
        {
            Console.WriteLine($"{message}");
            Console.ReadKey();
            funcName?.Invoke();
        }

        /*
         * Function info
         * - Prompts the user to press the indicated key then executes the indicated function after.
         * 
         * Usage
         * - Call function directly
         * - Must indicate a message, a key, and a function to be called.
         */
        public static void singleKey(string message, Action? funcName, ConsoleKey key)
        {
            Console.WriteLine($"{message} ({key})");
            if (key == Console.ReadKey(true).Key) funcName?.Invoke();
        }

        /*
         * Function info
         * - Prompts the user to select from a list of provided options, then executes the respective function after.
         * - Has a default "Navigation" header. Modify as needed.
         * 
         * Usage
         * - Call function directly.
         * - Must indicate a List<>.
         *      - List contains a message, a key, and a function to be called.
         */
        public static void multKeys(List<(string message, Action? FuncName, ConsoleKey Key)> prompts, string header = "Navigation")
        {
            Console.WriteLine($"{header}");

            foreach (var prompt in prompts)
            {
                Console.WriteLine($" [{prompt.Key}] {prompt.message}");
            }

            bool validKeyPressed = false;
            while (!validKeyPressed)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                var match = prompts.FirstOrDefault(p => p.Key == input.Key);
                if (match.Key != default)
                {
                    validKeyPressed = true;
                    match.FuncName?.Invoke();
                }
            }
        }

        /*
         * Function info
         * - Prompts the user to enter { Y, y } or { N, n }, then executes the respective function after.
         * - Recursive; repeatedly asks for valid input.
         *
         * Usage
         * - Call function directly
         * - Must indicate a truthy ({ Y, y }) function and a falsey ({ N, n }) function.
         */
        public static void yn(string message, Action? TruthyFuncName, Action? FalseyFuncName)
        {
            Console.WriteLine($"{message} [y/n]");

            char input = Convert.ToChar(Console.ReadLine() ?? "");

            switch (input)
            {
                case 'Y': TruthyFuncName?.Invoke(); break;
                case 'y': TruthyFuncName?.Invoke(); break;
                case 'N': FalseyFuncName?.Invoke(); break;
                case 'n': FalseyFuncName?.Invoke(); break;

                default:
                    Out.printe("\rInvalid input." + new string(' ', Math.Max(0, message.Length - 14)) + "\n");
                    UserPrompt.yn(message, TruthyFuncName, FalseyFuncName);
                    break;
            }
        }

        /*
         * Function info
         * - Prompts the user to enter { Y, y } or { N, n }, then executes the respective function after.
         * - Breaks after a falsey { N, n } input.
         * - Recursive; repeatedly asks for valid input.
         *
         * Usage
         * - Call function directly
         * - Must indicate a truthy ({ Y, y }) function.
         */
        public static void ynf(string message, Action? TruthyFuncName)
        {
            Console.WriteLine($"{message} [y/n]");

            char input = Convert.ToChar(Console.ReadLine() ?? "");

            switch (input)
            {
                case 'Y': TruthyFuncName?.Invoke(); break;
                case 'y': TruthyFuncName?.Invoke(); break;
                case 'N': break;
                case 'n': break;

                default:
                    Out.printe("\rInvalid input." + new string(' ', Math.Max(0, message.Length - 14)) + "\n");
                    ynf(message, TruthyFuncName);
                    break;
            }
        }

    }

    /*
     * Class info
     * - A library of functions dedicated to ease displaying information.
     */
    class Out
    {

        /* -- C-inspired printf() wannabe funcs -- */

        /*
         * Function info
         * - Prints plain text.
         * - Does not create new lines automatically; must include '\n' at ends.
         * 
         * Usage
         * - Call function directly.
         * - Must indicate a message argument.
         */
        public static void printf(string message)
        {
            Console.Write(message);
        }

        /*
         * Function info
         * - Prints an affirming message to the console.
         * - Does not create new lines automatically; must include '\n' at ends.
         * 
         * Usage
         * - Call function directly.
         * - Must indicate a message argument.
         * - Customisation
         *      - bool tag       : Whether or not to show the message tag
         *      - string opening : Change the tag text
         */
        public static void printa(string message, bool tag = true, string opening = "[MSG] ")
        {
            string start = tag ? opening : "";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(start + message);
            Console.ResetColor();
        }

        /*
         * Function info
         * - Prints an alert message to the console.
         * - Does not create new lines automatically; must include '\n' at ends.
         * 
         * Usage
         * - Call function directly.
         * - Must indicate a message argument.
         * - Customisation
         *      - bool tag       : Whether or not to show the message tag
         *      - string opening : Change the tag text
         */
        public static void printw(string message, bool tag = true, string opening = "[LOG] ")
        {
            string start = tag ? opening : "";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(start + message);
            Console.ResetColor();
        }

        /*
         * Function info
         * - Prints an error message to the console.
         * - Does not create new lines automatically; must include '\n' at ends.
         * 
         * Usage
         * - Call function directly.
         * - Must indicate a message argument.
         * - Customisation
         *      - bool tag       : Whether or not to show the message tag
         *      - string opening : Change the tag text
         */
        public static void printe(string message, bool tag = true, string opening = "[ERR] ")
        {
            string start = tag ? opening : "";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(start + message);
            Console.ResetColor();
        }


        /* -- Console art display utils -- */

        /*
         * Function info
         * - Adds a separator line with a customisable width.
         * - Adds spacing above and below the separator.
         *
         * Usage
         * - Call function directly.
         * - Can set the width; has a default of 50
         */
        public static void separator(int amount = 52)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n" + new string('─', amount) + "\n");
            Console.ResetColor();
        }

        /*
         * Function info
         * - Instantiates a console art container with your desired header.
         * - For best results, ensure this has the same width as 'content' and 'end'.
         * 
         * Usage
         * - Call function directly.
         * - Indicate a header; has a default of EMPTY.
         * - Customisation
         *      - int width    : Set the width of the container; has a default of 50.
         *      - bool compact : Display an extra line for space or not.
         */        
        public static void aestheticContainerBegin(string title = "", int width = 50, bool compact = false)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"┌{new string('─', width)}┐");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"│");    

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{title.PadLeft((width + title.Length) / 2).PadRight(width)}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"│\n");

            Console.WriteLine($"├{new string('─', width)}┤");
            if (!compact) Console.WriteLine($"│{new string(' ', width)}│");
            Console.ResetColor();
        }

        /*
         * Function info
         * - Instantiates a console art container with your content neatly wrapped.
         * - For best results, ensure this has the same width as 'begin' and 'end'.
         * 
         * Usage
         * - Call function directly.
         * - Indicate the content.
         * - Customisation
         *      - int width    : Set the width of the container; has a default of 50.
         */        
        public static void aestheticContainerContent(string content, int width = 50)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"│");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($" {content.PadRight(width - 2)} ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"│\n");

            Console.ResetColor();
        }

        /*
         * Function info
         * - Instantiates a console art container footer.
         * - For best results, ensure this has the same width as 'begin' and 'content'.
         * 
         * Usage
         * - Call function directly.
         * - Customisation
         *      - int width    : Set the width of the container; has a default of 50.
         *      - bool compact : Display an extra line for space or not.
         */        
        public static void aestheticContainerEnd(int width = 50, bool compact = false)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (!compact) Console.WriteLine($"│{new string(' ', width)}│");
            Console.WriteLine($"└{new string('─', width)}┘");
            Console.ResetColor();
        }

        /*
         * Function info
         * - Starts a fake loading bar.
         * - Randomises process duration.
         * - Can be set to "pass" or "fail".
         * 
         * Usage
         * - Call function directly.
         * - Must indicate a message.
         * - Customisation
         *      - bool pass     : Whether or not the process "passes" or "fails"
         *      - bool animate  : Whether or not to add easing
         *      - int addedTime : Adds a few more seconds to the process duration; has a default of 0.
         */
        public static void fakeProcess(string message, bool pass, bool animate = true, int addedTime = 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);

            Random rng = new Random();
            int totalBars = 36;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n[");
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < totalBars; i++)
            {
                Console.Write("■");

                int delay;

                if (animate)
                {
                    double t = (double)i / (totalBars - 1);
                    double eased = 1 - Math.Pow(1 - t, 2);
                    delay = (int)(5 + eased * 45) + rng.Next(1, 12);
                }
                else
                {
                    delay = rng.Next(1, 35);
                }

                Thread.Sleep(delay + addedTime);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("]");

            if (pass)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" FAIL");
            }

            Console.WriteLine("");
            Console.ResetColor();

            Thread.Sleep(100);
        }

        /*
         * Function info
         * - Clears the screen.
         * 
         * Usage
         * - Call function directly.
         */
        public static void cls()
        {
            Console.Clear();
        }

        /*
         * Function info
         * - Delays the program for a set amount of milliseconds.
         * 
         * Usage
         * - Call function directly.
         * - Must indicate a delay duration in milliseconds.
         */
        public static void delay(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

    }
}