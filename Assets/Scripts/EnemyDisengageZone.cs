using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* EnemyDisengageZone.cs
* 
* Created By: Connor Morris
* Created On: 2018 Mar 26
* Last Edited By: Connor Morris
* Last Edited On: 2018 April 6
* 
*/

[AddComponentMenu("GDC/World/EnemyDisengageZone")]
public class EnemyDisengageZone : TriggerBox {
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy") //Enemies "dogpile" at the edge and then return to what they were doing
        {
            Debug.Log("We got here!");
            Disengage(other.GetComponent<Enemy>());
        }
    }

    public void Disengage(Enemy target)
    {
        target.IsTriggered = false;
        target.FollowTarget = null;
        target.AttackTarget = null;
    }
}

