using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzer;

namespace MoodAnalyzerTest
{
    [TestClass]
    public class AnalyzeTes
    {
        [TestMethod]
        public void ForSadMoodShouldReturnSad()
        {
            //Arrange
            string expected = "SAD";
            string message = "I am in Sad Mood";
            MoodAnalyse moodAnalyzer = new MoodAnalyse(message);

            //Act
            string mood = moodAnalyzer.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);

        }
    }
}
