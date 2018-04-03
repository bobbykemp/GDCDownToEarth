using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * NPCharacter.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 10
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 10
 * 
 */

[AddComponentMenu("GDC/Character/NPC")]
public class NPCharacter : Character
{
    /* Public Variables */
	public float minFollowDistance = 10; //set this to something ~10 in the edito - this is the minimum distance maintained between player and npc
    public float youCanOnlyBeThisFarAway = 5; //
	public float movementScalingFactor = 4.5f; //character movement was too slow
	public GameObject target;

    /* Getter and Setter */
	public float MinFollowDist
	{
		get { return minFollowDistance; }
		set { minFollowDistance = value; }
	}

    public float MaxFollowDist
    {
        get { return minFollowDistance; }
        set { youCanOnlyBeThisFarAway = value; }
    }

    /* Unity Functions */
    public override void Awake()
    {
        base.Awake(); // Since we are overcasting Character Awake function, need to call it.
        Chartype = CharType.NPC; // Need to make sure our NPC is N.P.C!
    }

    public virtual void FixedUpdate()
    {
		Follow (target);
    }
    
    /* Functions */
    public virtual void Follow(GameObject target) // Its virtual. If Enemy class have more complex function, override it.
    {
        Vector2 dist = transform.position - target.transform.position; // How far am I?
		Vector2 targetSpeed = target.GetComponent<Rigidbody2D>().velocity;
		bool targetIsMoving = target.GetComponent<PlayerMovement> ().getMoving ();
        int dir = 1;

		Debug.Log (transform.eulerAngles.x);

		if (dist.magnitude > MinFollowDist && targetIsMoving) // Am I too far from target?
        { 
			dir = dist.x > 0 ? -1 : 1; // Set direction based on which side of target I'm on (now facing toward target)
			//Debug.Log ("too far from target");
			Vector2 vel = new Vector2 (H_CurrSpeed, body.velocity.y); // Update velocity profile
			body.velocity = vel * dir * movementScalingFactor; // Set velocity to our character
		}
		else if(dist.magnitude <= MinFollowDist && targetIsMoving)
        {
            dir = dist.x > 0 ? 1 : -1; // Set direction based on which side of target I'm on (now facing toward target)
            //Debug.Log("too close to target");
            Vector2 vel = new Vector2(H_CurrSpeed, body.velocity.y); // Update velocity profile
            body.velocity = vel * dir * movementScalingFactor; // Set velocity to our character
        }
       	else {
			body.velocity = new Vector2(0, body.velocity.y);
		}

    }

	public void Meander(){		//idly wander around waiting for something to happen
		//TODO add obstacle navigation logic (pathfinding?)
			
	}

    public override void Attack(Character target)
    {
        //if(target.Chartype == CharType.ENEMY) // Attack if and only if target character is enemy
            base.Attack(target);
    }

    public override void Jump()
    {
        base.Jump();
    }
}
