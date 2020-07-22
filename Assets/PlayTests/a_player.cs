using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace a_player
{
    public static class Helpers
    {
        // If we need to clean the slate, often better to just reload the scene
        public static IEnumerator LoadMovementTestsScene()
        {
            var operation = SceneManager.LoadSceneAsync("MovementTests");
            while (operation.isDone == false)
                yield return null;
        }

        public static Player GetPlayer()
        {
            // This method of finding things is slow, but it's a unit test so it's fine.
            Player player = GameObject.FindObjectOfType<Player>();
            
            // Need to substitute the player inputs
            var testPlayerInput = Substitute.For<IPlayerInput>();
            player.PlayerInput = testPlayerInput;

            return player;
        }

        public static float CalculateTurn(Quaternion originalRotation, Quaternion currentRotation)
        {
            // Can change Quaternion to a Vector3 by multiplying by Vector3.forward
            var cross = Vector3.Cross(originalRotation * Vector3.forward, currentRotation * Vector3.forward);
            var dot = Vector3.Dot(cross, Vector3.up);

            return dot;
        }
    }
    
    // TODO: Rename class so that it  represents most basic movement
    public class with_positive_vertical_input
    {       
        [UnityTest]
        public IEnumerator moves_forward()
        {
            yield return Helpers.LoadMovementTestsScene();

            var player = Helpers.GetPlayer();

            player.PlayerInput.Vertical.Returns(1f);
            player.PlayerInput.Horizontal.Returns(1f);
            
            float startingZPosition = player.transform.position.z;
            float startingXPosition = player.transform.position.x;
            yield return new WaitForSeconds(1f);
            float endingZPosition = player.transform.position.z;
            float endingXPosition = player.transform.position.x;

            Assert.Greater(endingZPosition, startingZPosition);
            Assert.Greater(endingXPosition, startingXPosition);
        }
    }
    
    public class with_negative_vertical_input
    {       
        [UnityTest]
        public IEnumerator moves_back()
        {
            yield return Helpers.LoadMovementTestsScene();

            var player = Helpers.GetPlayer();

            player.PlayerInput.Vertical.Returns(-1f);
            player.PlayerInput.Horizontal.Returns(-1f);
            
            float startingZPosition = player.transform.position.z;
            float startingXPosition = player.transform.position.x;
            yield return new WaitForSeconds(1f);
            float endingZPosition = player.transform.position.z;
            float endingXPosition = player.transform.position.x;

            Assert.Less(endingZPosition, startingZPosition);
            Assert.Less(endingXPosition, startingXPosition);
        }
    }
    
    public class with_negative_mouse_x
    {
        [UnityTest]
        public IEnumerator turns_left()
        {
            yield return Helpers.LoadMovementTestsScene();
            var player = Helpers.GetPlayer();

            var originalRotation = player.transform.rotation;
            
            player.PlayerInput.MouseX.Returns(-1f);
            yield return new WaitForSeconds(0.5f);

            float turnAmount = Helpers.CalculateTurn(originalRotation, player.transform.rotation);
            
            Assert.Less(turnAmount, 0);
        }
    }
    
    public class with_positive_mouse_x
    {
        [UnityTest]
        public IEnumerator turns_right()
        {
            yield return Helpers.LoadMovementTestsScene();
            var player = Helpers.GetPlayer();

            var originalRotation = player.transform.rotation;
            
            player.PlayerInput.MouseX.Returns(1f);
            yield return new WaitForSeconds(0.5f);

            float turnAmount = Helpers.CalculateTurn(originalRotation, player.transform.rotation);
            
            Assert.Greater(turnAmount, 0);
        }
    }
}