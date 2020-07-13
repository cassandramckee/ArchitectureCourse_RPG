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

            var player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            player.AddComponent<CharacterController>();
            player.AddComponent<Player>();

            yield return new WaitForSeconds(5f);
        }
    }
}