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

        [TestMethod]
        public void GivenMoodAnalyserClassNameShouldReturn_MoodAnalyserObject()
        {
            MoodAnalyser expected = new MoodAnalyser();
            object actual = MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyzer.MoodAnalyser","MoodAnalyser");
            expected.Equals(actual);
        }
    }
}
