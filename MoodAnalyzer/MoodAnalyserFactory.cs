﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyserFactory
    {
        //UC4
        public static object CreateMoodAnalyser(string className, string constructor)
        {
            string pattern = @"." + constructor + "$";
            if (Regex.IsMatch(className, pattern))
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    //Type moodAnalyseType = assembly.GetType(className);
                    Type moodAnalyseType = assembly.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Class Name not found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor Name not found");
            }
        }



        //UC5
        public static object CreateMoodAnalyser_ParameterizedConstructor(string className, string constructor, string message)
        {
            Type type = Type.GetType("MoodAnalyzer.MoodAnalyser");
            if (type.FullName.Equals(className) || type.Name.Equals(className))
            {
                if (type.Name.Equals(constructor))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    object instance = constructorInfo.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor Name not found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Class Name not found");
            }

        }

        //UC6
        public static string InvokeAnalyseMethod(string methodName, string message)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyzer.MoodAnalyser");
                object moodAnalyser = MoodAnalyserFactory.CreateMoodAnalyser_ParameterizedConstructor("MoodAnalyzer.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object method = methodInfo.Invoke(moodAnalyser, null);
                return method.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Method Not Found");
            }
        }


        //UC7
        public static string SetField(string fieldName, string message)
        {
            try
            {
                if (message == null)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELD,"Message can't be null");
                }
                MoodAnalyser moodAnalyser = new MoodAnalyser();
                Type type = Type.GetType("MoodAnalyzer.MoodAnalyser");
                //Create FieldInfo obj by defining fieldname & declare it as public and instance variable
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                field.SetValue(moodAnalyser,message);
                return moodAnalyser.message;  //Here, message is the variable of MoodAnalyse class
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELD,"Mentioned Field isn't there");
            }
        }

    }
}
