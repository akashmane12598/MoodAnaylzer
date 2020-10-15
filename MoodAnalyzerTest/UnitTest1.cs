using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzer;
using System;

namespace MoodAnalyzerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNullMessage()
        {
            string actual;
            try
            {
                //Arrange
                MoodAnalyser mood = new MoodAnalyser(null);
                //Act
                actual = mood.AnalyseMood();
            }
            catch (MoodAnalyserCustomException e)
            {
                actual = e.Message;
            }
            //Assert
            Assert.AreNotEqual("Happy Mood", actual);
        }

        [TestMethod]
        public void TestEmptyMessage()
        {
            MoodAnalyser mood = new MoodAnalyser(string.Empty);
            string actual;
            try
            {
                actual = mood.AnalyseMood();
            }
            catch(MoodAnalyserCustomException e)
            {
                actual = e.Message;
            }
            Assert.AreEqual("String shouldn't be empty", actual);
        }

        [TestMethod]
        public void TestHappyMessage()
        {
            MoodAnalyser mood = new MoodAnalyser("I am in Happy Mood right now");
            string actual = mood.AnalyseMood();
            Assert.AreEqual("Happy Mood", actual);
        }

        [TestMethod]
        public void TestSadMessage()
        {
            MoodAnalyser mood = new MoodAnalyser("I am in Sad Mood right now");
            string actual = mood.AnalyseMood();
            Assert.AreEqual("Sad Mood", actual);
        }

        //TC4.1
        [TestMethod]
        public void GivenMoodAnalyserClassNameShouldReturn_MoodAnalyserObject_TC4_1()
        {
            MoodAnalyser expected = new MoodAnalyser();
            object actual = MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyzer.MoodAnalyser", "MoodAnalyser");
            expected.Equals(actual);
        }

        //TC4.2 Improper class name
        [TestMethod]
        public void GivenMoodAnalyserClassNameShouldReturn_MoodAnalyserObject_TC_4_2()
        {
            object expected = null;
            object actual = null;
            try
            {
                expected = new MoodAnalyser();
                actual = MoodAnalyserFactory.CreateMoodAnalyser("ModAnalyzer.MoodAnalyser", "MoodAnalyser");
            }
            catch (MoodAnalyserCustomException m)
            {
                Console.WriteLine(m.Message);
            }
            finally
            {
                expected.Equals(actual);
            }

        }

        //TC4.3 Improper constructor name
        [TestMethod]
        public void GivenMoodAnalyserClassNameShouldReturn_MoodAnalyserObject_TC_4_3()
        {
            object expected = null;
            object actual = null;
            try
            {
                expected = new MoodAnalyser();
                actual = MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyzer.MoodAnalyser", "ModAnalyser");
            }
            catch (MoodAnalyserCustomException m)
            {
                Console.WriteLine(m.Message);
            }
            finally
            {
                expected.Equals(actual);
            }

        }

        //TC5.1
        [TestMethod]
        public void GivenMoodAnalyserClassNameShouldReturn_MoodAnalyserObject_UsingParameterizedConstructor_TC5_1()
        {
            MoodAnalyser expected = new MoodAnalyser("Happy");
            object actual = MoodAnalyserFactory.CreateMoodAnalyser_ParameterizedConstructor("MoodAnalyzer.MoodAnalyser", "MoodAnalyser", "Happy");
            expected.GetType().Equals(actual.GetType());
        }

        //TC5.2 Improper Class name
        [TestMethod]
        public void GivenMoodAnalyserClassNameShouldReturn_MoodAnalyserObject_UsingParameterizedConstructor_TC5_2()
        {
            object expected = null;
            object actual = null;
            try
            {
                expected = new MoodAnalyser("Happy");
                actual = MoodAnalyserFactory.CreateMoodAnalyser_ParameterizedConstructor("ModAnalyzer.MoodAnalyser", "MoodAnalyser", "Happy");
            }
            catch (MoodAnalyserCustomException m)
            {
                Console.WriteLine(m.Message);
            }
            finally
            {
                expected.Equals(actual);
            }
        }


        //TC5.3 Improper Constructor name
        [TestMethod]
        public void GivenMoodAnalyserClassNameShouldReturn_MoodAnalyserObject_UsingParameterizedConstructor_TC5_3()
        {
            object expected = null;
            object actual = null;
            try
            {
                expected = new MoodAnalyser("Happy");
                actual = MoodAnalyserFactory.CreateMoodAnalyser_ParameterizedConstructor("MoodAnalyzer.MoodAnalyser", "MdAnalyser", "Happy");
            }
            catch (MoodAnalyserCustomException m)
            {
                Console.WriteLine(m.Message);
            }
            finally
            {
                expected.Equals(actual);
            }
        }


        //TC6.1
        [TestMethod]
        public void TestingMethodsCalledThroughReflection_6_1()
        {             
            object expected = "Happy Mood";
            object actual = MoodAnalyserFactory.InvokeAnalyseMethod("AnalyseMood", "I am in Happy Mood");
            Assert.AreEqual(expected, actual);            
        }


        //TC6.2 Improper Method Name
        [TestMethod]
        public void TestingMethodsCalledThroughReflection_6_2()
        {
            object actual = null;
            object expected = null;
            try
            {
                expected = "Happy Mood";
                actual = MoodAnalyserFactory.InvokeAnalyseMethod("Analyse","I am in Happy Mood");                
            }
            catch (MoodAnalyserCustomException e)
            {
                actual = e.Message;
            }
            finally
            {
                Assert.AreEqual(expected,actual);
            }
        }
    }
}
