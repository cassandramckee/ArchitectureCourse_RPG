using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTeleporter : ItemComponent
{
    protected override void Use()
    {
        var player = GameObject.FindObjectOfType<Player>();
        //var player = Get<Player>();
        // TODO How to set player to this? Need to find player transform
        player.transform.position = new Vector3(
            player.transform.position.x, 
            player.transform.position.y + 1f, 
            player.transform.position.z);
    }
}
