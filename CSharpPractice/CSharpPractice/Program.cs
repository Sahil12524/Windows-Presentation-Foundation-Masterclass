using CSharpPractice.Classes;
using CSharpPractice.Interfaces;

namespace CSharpPractice;

internal class Program
{
    private static readonly double numberTwo = 12.34;

    static void Main(string[] args)
    {
        var numbers = new double[] { 1, 2, 3, 42, 42154 };
        var result = SimpleMath.Add(numbers);
        Console.WriteLine(result);

        BankAccount bankAccount = new BankAccount(1000);
        bankAccount.AddToBalance(100);
        Console.WriteLine(bankAccount.Balance);

        ChildBankAccount childBankAccount = new ChildBankAccount();
        childBankAccount.AddToBalance(10);
        Console.WriteLine(childBankAccount.Balance);

        SimpleMath simpleMath = new SimpleMath();

        Console.WriteLine(Information(bankAccount));
        Console.WriteLine(Information(simpleMath));

        Console.ReadLine();
    }

    private static string Information(IInformation information)
    {
        return information.GetInformation();
    }

    class SimpleMath : IInformation
    {
        public static double Add(double n1, double n2) => n1 + n2;

        public static double Add(double[] numbers)
        {
            double result = 0;
            foreach (var d in numbers)
            {
                result += d;
            }
            return result;
        }

        public string GetInformation()
        {
            return "Class that solves simple math.";
        }
    }
}
