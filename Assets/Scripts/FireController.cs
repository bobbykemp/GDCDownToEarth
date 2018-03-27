using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * FireController.cs
 * 
 * Created By: Joseph Brewster
 * Created On: 2018 Mar 19
 * Last Edited By Joseph Brewster
 * Last Edited On 2018 Mar 22
 * 
 */
 [AddComponentMenu("GDC/World/FireController")]
public class FireController : MonoBehaviour {
    [Range(1,75)]
    public int fireDamage;
    public Sprite FireOnDisp;              // For asthetics
    public Sprite FireOffDisp;
    private SpriteRenderer firesr;

    public void Update()
    {
        firesr = GetComponent<SpriteRenderer>();
        firesr.sprite = FireOnDisp;
    }

    // Display fire and damage player
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //TODO: Damage player with fire by method call
        }

        if (other.gameObject.tag.Equals("Extinguisher")&& Input.GetKeyDown("e"))
        {
            if (fireDamage < 50)
            {
                fireDamage = 0;
                firesr.sprite = FireOffDisp;
            }
            else
            {
                Debug.Log("Fire too strong to be extinguished");
            }
        }
    }
}

    
