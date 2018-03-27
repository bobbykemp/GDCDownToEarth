using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour 
{
	public int damage;
	public bool canAttack, inRange;
	GameObject enemyObj;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Enemy")) 
		{
			enemyObj = other.gameObject;
			inRange = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Enemy")) 
		{
			enemyObj = null;
			inRange = false;
		}
	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.F) && canAttack) 
		{
			Debug.Log ("Attacked!");
			canAttack = false;
			if (enemyObj != null && inRange)
			{
				//Dea Damage
			}
		}
	}
}
