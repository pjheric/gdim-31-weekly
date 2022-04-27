using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPickup : Pickup
{
    //Child class of Pickup, this powerup multiplies the player's movement speed by a multiplier for a duration.
    [SerializeField] float powerupDuration = 5f;
    [SerializeField] float moveSpeedMultiplier = 3f; 
    [SerializeField] GameObject player; 
    public override void PickupObject(Collider2D player)
    {
        player.GetComponent<PlayerMovement>().walkSpeed *= moveSpeedMultiplier;
        Invoke(nameof(ResetEffect), powerupDuration); //Simply delays resetting the effect for 5 seconds.
        base.PickupObject(player);
    }
    private void ResetEffect()
    {
        player.GetComponent<PlayerMovement>().walkSpeed /= moveSpeedMultiplier; 
    }


}
