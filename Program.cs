Console.WriteLine("Simple Calculator");
Console.WriteLine("-----------------");

bool calculateAgain;

do
{
    double firstNumber = ReadNumber("Enter the first number: ");
    string operation = ReadOperation();
    double secondNumber = ReadNumber("Enter the second number: ");

    if (operation == "/" && secondNumber == 0)
    {
        Console.WriteLine("Cannot divide by zero.");
    }
    else
    {
        double result = operation switch
        {
            "+" => firstNumber + secondNumber,
            "-" => firstNumber - secondNumber,
            "*" => firstNumber * secondNumber,
            "/" => firstNumber / secondNumber,
            _ => throw new InvalidOperationException("Unsupported operation.")
        };

        Console.WriteLine($"Result: {result}");
    }

    Console.Write("Calculate again? (y/n): ");
    calculateAgain = Console.ReadLine()?.Trim().Equals("y", StringComparison.OrdinalIgnoreCase) == true;
    Console.WriteLine();
} while (calculateAgain);

Console.WriteLine("Goodbye!");

static double ReadNumber(string prompt)
{
    while (true)
    {
        Console.Write(prompt);

        if (double.TryParse(Console.ReadLine(), out double number))
        {
            return number;
        }

        Console.WriteLine("Please enter a valid number.");
    }
}

static string ReadOperation()
{
    while (true)
    {
        Console.Write("Choose an operation (+, -, *, /): ");
        string? operation = Console.ReadLine()?.Trim();

        if (operation is "+" or "-" or "*" or "/")
        {
            return operation;
        }

        Console.WriteLine("Please choose +, -, *, or /.");
    }
}
