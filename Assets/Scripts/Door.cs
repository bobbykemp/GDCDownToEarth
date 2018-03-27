using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Door.cs
* 
* Created By: Joseph Brewster
* Created On: 2018 Mar 19
* Last Edited By: Joseph Brewster
* Last Edited On: 2018 Mar 22
* 
*/

[AddComponentMenu("GDC/World/Door")]
public class Door : MonoBehaviour {
    public Sprite doorOpen;
    public Sprite doorClose;            //Astheetics
    public bool open = false;
    private SpriteRenderer sr;
    public GameObject doorBlock;    //Internal collider for door

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    //If in range, open or close door
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player") && Input.GetKeyDown("e"))
        {
            if (!open)
            {
                sr.sprite = doorOpen;
                open = true;
                doorBlock.SetActive(false);
                Debug.Log("Door is open");
            }
            else if (open)
            {
                sr.sprite = doorClose;
                open = false;
                doorBlock.SetActive(true);
                Debug.Log("Door is closed");
            }
        }
   
              
    }

 

}
