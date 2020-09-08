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
        private Player player;
        private Item item;

        [UnitySetUp]
        public IEnumerator init() {
            yield return Helpers.LoadItemTestsScene();
            player = Helpers.GetPlayer();
            
            player.PlayerInput.Vertical.Returns(1f);

            item = Object.FindObjectOfType<Item>();
        }
        
        [UnityTest]
        public IEnumerator picks_up_and_equips_item()
        {
            Assert.AreNotSame(item, player.GetComponent<Inventory>().ActiveItem);
            
            yield return new WaitForSeconds(0.5f);
            
            // GetComponent will probably become a field later since we will want
            // to get items a lot.
            Assert.AreSame(item, player.GetComponent<Inventory>().ActiveItem);
        }
        
        [UnityTest]
        public IEnumerator changes_crosshair_to_item_crosshair()
        {
            var crosshair = Object.FindObjectOfType<Crosshair>();
            
            // Do our check to insert that the crosshairs are different
            Assert.AreNotSame(item.CrosshairDefinition.Sprite, crosshair.GetComponent<Image>().sprite);

            // Move item to the player
            item.transform.position = player.transform.position;
            
            // We need to wait for collision processing to happen
            yield return new WaitForFixedUpdate();
            
            // Now do our check that the crosshairs are the same
            Assert.AreEqual(item.CrosshairDefinition.Sprite, crosshair.GetComponent<Image>().sprite);
        }
        
        [UnityTest]
        public IEnumerator changes_slot_1_icon_to_match_item_icon()
        {
            var hotbar = Object.FindObjectOfType<Hotbar>();
            var slotOne = hotbar.GetComponentInChildren<Slot>();
            
            // Do our check to insert that the crosshairs are different
            Assert.AreNotSame(item.Icon, slotOne.IconImage.sprite);

            // Move item to the player
            item.transform.position = player.transform.position;
            // We need to wait for collision processing to happen
            yield return new WaitForFixedUpdate();
            
            // Now do our check that the crosshairs are the same
            Assert.AreEqual(item.Icon, slotOne.IconImage.sprite);
        }
    }
}