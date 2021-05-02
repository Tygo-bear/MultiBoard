using System.Collections.Generic;

namespace MultiBoardKeyboard
{
    public static class ErrorReport
    {
        private static List<ErrorEvent> _errorEvents = new List<ErrorEvent>();

        public static void AddEvent(ErrorEvent e)
        {
            _errorEvents.Add(e);
        }

        public static void RemoveEvent(ErrorEvent e)
        {
            _errorEvents.Remove(e);
        }

        public static void ClearEvents()
        {
            _errorEvents.Clear();
        }

        public static string CreateReport()
        {
            string response = "";

            foreach (ErrorEvent e in _errorEvents)
            {
                response += e.ToString() + '\n';
            }

            return response;
        }

    }

    public class ErrorEvent
    {
        public string Title;
        public string Description;
        public ErrorType Type;

        public override string ToString()
        {
            return $"{Type}: {Title}, {Description}";
        }
    }

    public enum ErrorType
    {
        Event,
        Warning,
        Error
    }
}