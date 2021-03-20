namespace NakusiGames.Logger
{
    public class ConsoleLogger : ILogger
    {
        private string _owner;

        public ConsoleLogger(System.Type type)
        {
            _owner = type.Name;
        }
        
        public void Debug(string message)
        {
            UnityEngine.Debug.Log($"[DEBUG] {_owner}: {message}");
        }
    }
}