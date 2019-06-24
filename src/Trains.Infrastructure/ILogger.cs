namespace Trains.Infrastructure
{
    public interface ILogger
    {
        void trace(string message);
        void debug(string message);
        void info(string message);
        void warning(string message);
        void error(string message);
        void fatal(string message);
    }
}