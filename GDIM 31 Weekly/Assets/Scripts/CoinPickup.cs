using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : Pickup
{
    [SerializeField] int pointsForCoinPickup = 20;
    public override void PickupObject(Collider2D player)
    {
        FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup); 
        base.PickupObject(player);
    }
}
