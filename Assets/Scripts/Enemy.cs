using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

	public GameObject target;
	private Vector2 current;
	public int damage_to_player;

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate () {
		Vector2 toTarget = target.transform.position - transform.position;
		float speed = 1f;

		//transform.Translate(toTarget * speed * Time.deltaTime);
		Vector3 underPlayer = new Vector3 (Mathf.Lerp (target.transform.position.x, transform.position.x, speed * Time.deltaTime), transform.position.y, transform.position.z);
		transform.Translate (underPlayer * speed * Time.deltaTime);

	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			//Damage player
			Debug.Log("hit player");
			target.GetComponent<PlayerMovement> ().TakeDamage (damage_to_player);
		}

	}
}
