using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTeleporter : ItemComponent
{
    public override void Use()
    {
        var player = transform.root.transform.gameObject;
        //var player = Get<Player>();
        // TODO How to set player to this? Need to find player transform
        player.transform.position = new Vector3(
            player.transform.position.x, 
            player.transform.position.y + 5f, 
            player.transform.position.z);
    }
}
