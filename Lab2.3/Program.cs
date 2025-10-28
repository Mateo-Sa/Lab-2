// Интерфейс для реализации логирования
public interface ILog
{
    void Log(string message);
}
// Абстрактный класс
public abstract class Logger
{
    protected ILog _logImplementor; 

    protected Logger(ILog logImplementor)
    {
        _logImplementor = logImplementor;
    }
    public abstract void LogMessage(string message); // Абстрактный метод логирования с доп. логикой
}
// Класс, расширяющий функциональность логирования
public class FormattedLogger : Logger
{
    public FormattedLogger(ILog logImplementor) : base(logImplementor) { }

    public override void LogMessage(string message)
    {
        _logImplementor.Log($"[INFO] {message}"); 
    }
}
// Конкретная реализация логирования в консоль
public class ConsoleLog : ILog
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
public class Proga
{
    public static void Main(string[] args)
    {
        // Создаем реализацию (вывод в консоль)
        ILog consoleLog = new ConsoleLog();

        // Создаем мост: Логгер + Реализация (вывод в консоль)
        Logger logger = new FormattedLogger(consoleLog);

        // Используем логгер
        logger.LogMessage("Товар добавлен в корзину");
    }
}