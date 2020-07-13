using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace a_player
{
    // TODO: Rename class so that it  represents most basic movement
    public class with_positive_vertical_input
    {
        
        
        [UnityTest]
        public IEnumerator moves_forward()
        {
            var floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
            floor.transform.localScale = new Vector3(50f, 0.1f, 50f);
            floor.transform.position = Vector3.zero;

            var playerGameObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            playerGameObject.AddComponent<CharacterController>();
            playerGameObject.transform.position = new Vector3(0f, 1.5f, 0f);

            Player player = playerGameObject.AddComponent<Player>();
            var testPlayerInput = Substitute.For<IPlayerInput>();
            player.PlayerInput = testPlayerInput;

            testPlayerInput.Vertical.Returns(1f);
            testPlayerInput.Horizontal.Returns(1f);
            
            float startingZPosition = player.transform.position.z;
            float startingXPosition = player.transform.position.x;
            yield return new WaitForSeconds(1f);
            float endingZPosition = player.transform.position.z;
            float endingXPosition = player.transform.position.x;

            Assert.Greater(endingZPosition, startingZPosition);
            Assert.Greater(endingXPosition, startingXPosition);
        }
    }
}