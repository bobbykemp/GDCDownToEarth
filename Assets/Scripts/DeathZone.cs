using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("GDC/World/Hazards")]
public class DeathZone : MonoBehaviour {

    /*
 * Character.cs
 * 
 * Created By: Salvatore Calderone
 * Created On: 2017 Nov 17
 * Last Edited By: Salvatore Calderone
 * Last Edited On: 2017 Nov 17
 * 
 */

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "NPC" || other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);  // Is this needed for all GO's, including objects in the world that fall?
                                        // TODO: Potentially optimize to only check for player and respawn, otherwise destroy
        }
        else if (other.gameObject.tag == "Player")
        {
            // TODO: Link GameManager Object and call the respawn function.
            Debug.Log("Player Respawn");
        }
    }
}
