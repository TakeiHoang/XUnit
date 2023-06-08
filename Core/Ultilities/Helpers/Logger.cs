using Xunit.Abstractions;

namespace Core.Ultilities.Helpers
{
    public class Logger
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Logger(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        public void Text(string message)
        {
            Log(message);
        }

        public void Info(string message)
        {
            Log(message, "INFO");
        }

        public void Warning(string message)
        {
            Log(message, "WARNING");
        }

        public void Error(string message)
        {
            Log(message, "ERROR");
        }

        private void Log(string message, string messageType = "")
        {
            if (string.IsNullOrEmpty(messageType))
                _testOutputHelper.WriteLine($"{message}");
            else
                _testOutputHelper.WriteLine($"[{messageType}] {message}");
        }
    }
}