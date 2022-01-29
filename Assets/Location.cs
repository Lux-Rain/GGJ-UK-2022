using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public GameObject currentLocation;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "RoomBox")
        {
            currentLocation = collision.gameObject;
        }
        
    }
}
