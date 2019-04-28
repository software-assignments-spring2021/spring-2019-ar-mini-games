using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Tests
{
    public class BoardControllerUnitTests
    {
        [Test]
        public void InitialGameObjectState()
        {
            // Assert that a dartboard, dart, score, and highscore exist in the scene:
            Assert.NotNull(GameObject.FindGameObjectsWithTag("DartBoard"));
            Assert.NotNull(GameObject.Find("Dart"));
            Assert.NotNull(GameObject.Find("Score"));
            Assert.NotNull(GameObject.Find("HighScore"));
        }

        /*
         * BUG: Unity Test Runner does not clear the scene before each test, we'll need to implement somehow.
         **/
        [Test]
        public void BoardController_InitialScoreValues()
        {
            // Assert that "Score" is initially 0:
            Text scoreText = GameObject.Find("Score").GetComponent<Text>();
            Assert.NotNull(scoreText.text);
            Assert.AreEqual("Score: 0", scoreText.text);
        }

        [Test]
        public void BoardController_UpdateScores_Typical()
        {
            // Arrange
            int initialScore = 0;
            int newPoints = 6;
            int expectedScore = initialScore + newPoints;
            GameObject Test = new GameObject();
            Test.AddComponent<BoardController>();
            Test.GetComponent<BoardController>().scoreText = GameObject.Find("Score").GetComponent<Text>();
            Test.GetComponent<BoardController>().highScoreText = GameObject.Find("HighScore").GetComponent<Text>();

            // Act
            Test.GetComponent<BoardController>().UpdateScore(newPoints);

            // Assert
            Assert.AreEqual(expectedScore, Test.GetComponent<BoardController>().scoreText);
        }

        [Test]
        public void BoardController_UpdateScores_IgnoreNegatives()
        {
            // Arrange
            int initialScore = 0;
            int newPoints = -100;
            int expectedScore = initialScore + newPoints;
            GameObject Test = new GameObject();
            Test.AddComponent<BoardController>();
            Test.GetComponent<BoardController>().scoreText = GameObject.Find("Score").GetComponent<Text>();
            Test.GetComponent<BoardController>().highScoreText = GameObject.Find("HighScore").GetComponent<Text>();

            // Act
            Test.GetComponent<BoardController>().UpdateScore(newPoints);

            // Assert
            Assert.AreNotEqual(expectedScore, Test.GetComponent<BoardController>().Score);
        }

        [Test]
        public void BoardController_UpdateScores_GreaterHighScore()
        {
            // Arrange
            int initialScore = 0;
            int newPoints = -100;
            int expectedScore = initialScore + newPoints;
            GameObject Test = new GameObject();
            Test.AddComponent<BoardController>();
            Test.GetComponent<BoardController>().scoreText = GameObject.Find("Score").GetComponent<Text>();
            Test.GetComponent<BoardController>().highScoreText = GameObject.Find("HighScore").GetComponent<Text>();

            // Act
            Test.GetComponent<BoardController>().UpdateScore(newPoints);

            // Assert
            Assert.AreNotEqual(expectedScore, Test.GetComponent<BoardController>().Score);
        }

        [Test]
        public void BoardController_UpdateScoresText_Typical()
        {
            // Arrange
            int newPoints = 6;
            string expectedScore = "Score: 6";
            string expectedHighScore = "High Score: 6";
            Text scoreTextComponent = GameObject.Find("Score").GetComponent<Text>();
            Text highScoreTextComponent = GameObject.Find("HighScore").GetComponent<Text>();

            GameObject Test = new GameObject();
            Test.AddComponent<BoardController>();
            Test.GetComponent<BoardController>().scoreText = scoreTextComponent;
            Test.GetComponent<BoardController>().highScoreText = highScoreTextComponent;

            // Act
            Test.GetComponent<BoardController>().UpdateScore(newPoints);

            // Assert
            Assert.AreEqual(newPoints, Test.GetComponent<BoardController>().Score);
            Assert.AreEqual(newPoints, Test.GetComponent<BoardController>().HighScore);
            Assert.AreEqual(expectedScore, scoreTextComponent.text);
            Assert.AreEqual(expectedHighScore, highScoreTextComponent.text);
        }
    }
}
