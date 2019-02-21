using System.Collections.Generic;

namespace MultiBoard.ErrorSystem
{
    class Errors
    {
        private List<string> _errorMessage = new List<string>();
        private List<string> _errorCode = new List<string>();

        public void clearErrors()
        {
            _errorMessage.Clear();
            _errorCode.Clear();
        }

        public void addError(string errorCode, string errorMessage)
        {
            _errorCode.Add(errorCode);
            _errorMessage.Add(errorMessage);
        }

        public List<string> getErrorMessages()
        {
            return _errorMessage;
        }

        public List<string> getErrorCodes()
        {
            return _errorCode;
        }

        public void deleteByIndex(int index)
        {
            _errorCode.RemoveAt(index);
            _errorMessage.RemoveAt(index);
        }

    }
}
