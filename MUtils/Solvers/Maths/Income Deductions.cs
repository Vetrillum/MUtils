// Rand() Headers
using Kernel;

// C# Headers
using System;

class IncomeDeductions
{
    public static void Nav()
    {
        Kernel.Out.cls();

        Kernel.UserPrompt.multKeysf(new List<(string Message, Action? FuncName, ConsoleKey Key)>
        {
            ("Tax Deductions", TaxDeductions, ConsoleKey.D1),
            ("Mandatory Payroll Deduction", MandatoryPayrollDeduction, ConsoleKey.D2),
            ("Back", Navigation.NMaths, ConsoleKey.D0)
        }, "Income Deductions");
    }

    public static void TaxDeductions()
    {
        Kernel.Out.cls();



        Kernel.UserPrompt.submenu(TaxDeductions, Nav, "Tax Deductions");
    }

    public static void MandatoryPayrollDeduction()
    {
        Kernel.Out.cls();

        Kernel.UserPrompt.submenu(MandatoryPayrollDeduction, Nav, "Mandatory Payroll Deduction");
    }

    
    class Helpers
    {
        /* Tax Deduction Specific */
        public static void DisplayTaxTable()
        {

        }
    }
}