//Задание 1

//Создайте консольный мини-калькулятор, который будет подсчитывать сумму двух чисел. 
//Определите интерфейс для функции сложения числа и реализуйте его.
//Дополнительно: добавьте конструкцию Try/Catch/Finally для проверки корректности введённого значения.

//Задание 2

//Реализуйте механизм внедрения зависимостей:
//добавьте в мини-калькулятор логгер, используя материал из скринкаста юнита 10.1.
//Дополнительно: текст ошибки, выводимый в логгере, окрасьте в красный цвет, а текст события — в синий цвет.

Calculator calculator = new Calculator();
calculator.number();

interface ICalculator
{
    public void Sum(int a, int b);
}

class Calculator : ICalculator
{
    Logger logger = new Logger();
    
    public void number()
    {
        while (true)

            try
            {
                Console.WriteLine("Введите первый операнд");
                int operand1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nВведите второй операнд");
                int operand2 = Convert.ToInt32(Console.ReadLine());

                Sum(operand1, operand2);
                Console.WriteLine();
            }

            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
    }

    public void Sum(int a, int b)
    {
        logger.Event("\nПроизведен расчет");

        Console.WriteLine($"{a} + {b} = {a + b}");
    }
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
        Console.WriteLine("Произошла ошибка: Введены некоретные данные \n");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void Event(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

}

