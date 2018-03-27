using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench : MonoBehaviour {

    public bool IsPickUp = true;
    public GameObject player;               //The player object


    // In Range of object
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player") && Input.GetKeyDown("e"))     //Picks up item
        {
            this.transform.parent = player.transform;

        }

        if (other.gameObject.tag.Equals("Player") && Input.GetKeyDown("f"))    //Drops all items
        {
            player.transform.DetachChildren();

        }

    }
}
