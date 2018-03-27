using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* PressurePlate.cs
* 
* Created By: Joseph Brewster
* Created On: 2018 Feb 2
* Last Edited By: Joseph Brewster
* Last Edited On: 2018 Feb 2
* 
*/


[AddComponentMenu("GDC/World/PressurePlate")]
public class PressurePlate : MonoBehaviour{
    public bool Active = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        Active = true;
        Debug.Log("Active");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
            Active = false;
        Debug.Log("Inactive");
    }

}