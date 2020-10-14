using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyser
    {
        public string message;

        public MoodAnalyser()
        {

        }

        public MoodAnalyser(string msg)
        {
            this.message = msg;
        }
        public string AnalyseMood()
        {
            try
            {
                if (this.message.Contains("Sad"))
                {
                    return "Sad Mood";
                }
                if (this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.ENTERED_EMPTY, "String shouldn't be empty");
                }

                return "Happy Mood";
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.ENTERED_NULL, "string shouldn't be null");
            }

        }
    }
}