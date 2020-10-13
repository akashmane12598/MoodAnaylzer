using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyser(string className, string constructor)
        {
            string pattern = @"."+constructor+"$";
            if (Regex.IsMatch(className, pattern))
            {
                try
                {
                    //Assembly assembly = Assembly.GetExecutingAssembly();
                    //Type moodAnalyseType = assembly.GetType(className);
                    Type moodAnalyseType = Type.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (MoodAnalyserCustomException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS,"Class Name not found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD,"Constructor Name not found");
            }
        }
    }
}
