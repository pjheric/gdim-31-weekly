using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        PickupObject(collision); 
        
    }

    public virtual void PickupObject(Collider2D player)
    {
        if (player.tag == "Player")
        {
            gameObject.SetActive(false);  
        }
    }
}
