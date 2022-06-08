

Logger logger = new Logger();

Calculator calc = new Calculator(logger);

while (true)
{
    try
    {
        Console.Write("Введите 1-ое слагаемое: ");
        var a = Console.ReadLine();
        Console.Write("Введите 2-ое слагаемое: ");
        var b = Console.ReadLine();
        calc.Addition(Convert.ToInt32(a), Convert.ToInt32(b));
    }
    catch (Exception ex)
    {
        logger.Error(ex.Message);
    }
}

public interface IAddition
{
    void Addition(int a, int b);
}

public interface ILogger
{
    void Event(string message);
    void Error(string message);
}

public class Logger : ILogger
{
    public void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void Event(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Произошла ошибка: {0}", message);
        Console.ForegroundColor = ConsoleColor.White;
    }

}

public class Calculator : IAddition
{
    ILogger logger { get; }
    public Calculator(ILogger logger)
    {
        this.logger = logger;
    }
    public void Addition(int a, int b)
    {
        logger.Event("Посчитан результат");
        Console.WriteLine("Сумма чисел: {0}", a + b);
    }
}