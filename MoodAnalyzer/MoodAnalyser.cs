using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{

    public class MoodAnalyse
    {
        private string message;
        public MoodAnalyse(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {
            if (this.message.Contains("Sad"))
            {
                return "SAD";
            }
            return "HAPPY";
        }

    }
}