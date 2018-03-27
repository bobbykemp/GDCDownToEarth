/*
 *CameraBehavior.cs
 * 
 * Created By: Connor Morris
 * Created On: 2017 Nov 16
 * Last Edited By: Connor Morris
 * Last Edited On: 2017 Nov 16
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("GDC/Scripts/CameraBehavior.cs")]
public class CameraBehavior : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
