using System;
using System.Text;

namespace ExceptionExtensions
{
    public static class Extensions
    {
        #region Private Fields

        private const string MessageSeparator = " ";

        #endregion Private Fields

        #region Public Methods

        public static string GetMessageStack(this Exception exception, string separator = MessageSeparator)
        {
            var result = new StringBuilder();

            if (exception != default)
            {
                if (!string.IsNullOrWhiteSpace(exception.Message))
                {
                    result.Append(exception.Message.Trim());
                }

                if (exception.InnerException != default)
                {
                    var furtherMessages = exception.InnerException.GetMessageStack();

                    if (!string.IsNullOrWhiteSpace(furtherMessages))
                    {
                        if (result.Length > 0)
                        {
                            result.Append(separator);
                        }

                        result.Append(furtherMessages.Trim());
                    }
                }
            }

            return result.ToString();
        }

        #endregion Public Methods
    }
}