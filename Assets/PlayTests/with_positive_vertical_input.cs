using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;

namespace a_player
{
    public static class Helpers
    {
        public static void CreateFloor()
        {
            var floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
            floor.transform.localScale = new Vector3(50f, 0.1f, 50f);
            floor.transform.position = Vector3.zero;
        }

        public static Player CreatePlayer()
        {
            var playerGameObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            playerGameObject.AddComponent<CharacterController>();
            playerGameObject.AddComponent<NavMeshAgent>();
            playerGameObject.transform.position = new Vector3(0f, 1.5f, 0f);

            Player player = playerGameObject.AddComponent<Player>();
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
            Helpers.CreateFloor();

            var player = Helpers.CreatePlayer();

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
    
    public class with_negative_mouse_x
    {
        [UnityTest]
        public IEnumerator turns_left()
        {
            Helpers.CreateFloor();
            var player = Helpers.CreatePlayer();

            var originalRotation = player.transform.rotation;
            
            player.PlayerInput.MouseX.Returns(-1f);
            yield return new WaitForSeconds(0.5f);

            float turnAmount = Helpers.CalculateTurn(originalRotation, player.transform.rotation);
            
            Assert.Less(turnAmount, 0);
        }
    }
}