using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class NewTestScript
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            // Three parts to a test
            // 1) Arrange (most of the code is typically this part)
            List<string> myStrings = new List<string>();
            
            // 2) Act
            myStrings.Add("Scott's string");
            myStrings.Add("Scott's second string");
            myStrings.RemoveAt(0);
            
            // 3) Assert
            Assert.AreEqual(1, myStrings.Count);

        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
