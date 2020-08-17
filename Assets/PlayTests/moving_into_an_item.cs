using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace a_player
{
    public class moving_into_an_item
    {
        [UnityTest]
        public IEnumerator picks_up_and_equips_item()
        {
            yield return Helpers.LoadItemTestsScene();
            var player = Helpers.GetPlayer();
            
            player.PlayerInput.Vertical.Returns(1f);

            Item item = Object.FindObjectOfType<Item>();

            Assert.AreNotSame(item, player.GetComponent<Inventory>().ActiveItem);
            
            yield return new WaitForSeconds(1f);
            
            // GetComponent will probably become a field later since we will want
            // to get items a lot.
            Assert.AreSame(item, player.GetComponent<Inventory>().ActiveItem);
        }
        
        [UnityTest]
        public IEnumerator changes_crosshair_to_item_crosshair()
        {
            // We're getting the crosshair UI object and comparing it to the crosshair
            // on the only item in the scene, first making sure they're different,
            // then making sure they're the same once picked up.
            yield return Helpers.LoadItemTestsScene();
            
            var player = Helpers.GetPlayer();
            var crosshair = Object.FindObjectOfType<Crosshair>();
            
            Item item = Object.FindObjectOfType<Item>();

            // Do our check to insert that the crosshairs are different
            Assert.AreNotSame(item.CrosshairDefinition.Sprite, crosshair.GetComponent<Image>().sprite);

            // Move item to the player
            item.transform.position = player.transform.position;
            
            // Wait until end the next frame starts rendering
            yield return null;
            
            // Now do our check that the crosshairs are the same
            Assert.AreEqual(item.CrosshairDefinition.Sprite, crosshair.GetComponent<Image>().sprite);
        }
    }
}