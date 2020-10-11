using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyserCustomException : Exception
    {
        private readonly ExceptionType type;

        public enum ExceptionType
        {
            ENTERED_NULL, ENTERED_EMPTY,
            NO_SUCH_FIELD, NO_SUCH_METHOD,
            NO_SUCH_CLASS, OBJECT_CREATION_ISSUE
        }

        public MoodAnalyserCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}