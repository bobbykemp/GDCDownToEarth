using UnityEngine;
using System.Collections;

/*
 * AIMove.cs
 * 
 * Created By: Bobby Kemp
 * Created On: 2017 Nov 17
 * Last Edited By: Bobby Kemp
 * Last Edited On: 2017 Nov 17
 * 
 */

public class AIMove : MonoBehaviour {

	public float speed;             //Floating point variable to store the player's movement speed.
	public GameObject Target;
	public float follow_distance;
	private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

	void Start()
	{
		
	}

	void Update()
	{
		if (Vector2.Distance(transform.position, Target.transform.position) > follow_distance)
			transform.position = Vector2.MoveTowards (transform.position, Target.transform.position, speed * Time.deltaTime);
		if (Vector2.Distance(transform.position, Target.transform.position) < follow_distance)
			transform.position = Vector2.MoveTowards (transform.position, Target.transform.position, -speed * Time.deltaTime);
	}
}