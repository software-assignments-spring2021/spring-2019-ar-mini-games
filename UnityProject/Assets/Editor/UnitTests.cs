using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

namespace Tests
{
    public class UnitTests
    {
        [Test]
        public void UnitTestsSimplePasses()
        {
            // Assert that a dartboard and dart exist in the scene
            Assert.IsTrue(GameObject.Find("DartBoard") != null);
            Assert.IsTrue(GameObject.Find("Dart") != null);

            // Assert that "Score" exists and it is initially 0
            Text scoreText = GameObject.Find("Score").GetComponent<Text>();
            Assert.IsTrue(scoreText.text == "Score: 0");



        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator UnitTestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
