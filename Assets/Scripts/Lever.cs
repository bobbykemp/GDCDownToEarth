using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* Lever.cs
* 
* Created By: Joseph Brewster
* Created On: 2018 Mar 19
* Last Edited By: Joseph Brewster
* Last Edited On: 2018 Mar 22
* 
*/


[AddComponentMenu("GDC/World/Lever")]
public class Lever : MonoBehaviour
{
    public bool Active = false;             //State of lever
    public Sprite leverOnDisp;              // For asthetics
    public Sprite leverOffDisp;
    private SpriteRenderer levsr;

    private void Start()
    {
        levsr = GetComponent<SpriteRenderer>();     //Manages sprites
    }
    //Move lever if in range
    private void OnTriggerStay2D(Collider2D other)
    {   
        if (other.gameObject.tag.Equals("Player") && Input.GetKeyDown("e"))
        {
            if (!Active)
            {
                Active = true;
                levsr.sprite = leverOnDisp;
                Debug.Log("Switch on");
            }

            else if (Active)
            {
                Active = false;
                levsr.sprite = leverOffDisp;
                Debug.Log("Switch off");
            }
            
        }
    }

   

}