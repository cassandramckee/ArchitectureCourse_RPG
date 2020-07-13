using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace a_player
{
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
            player.PlayerInput.Vertical = 1;
            
            float startingZPosition = player.transform.position.z;
            yield return new WaitForSeconds(5f);
            float endingZPosition = player.transform.position.z;
            
            Assert.Greater(endingZPosition, startingZPosition);
        }
    }
}