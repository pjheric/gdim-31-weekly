using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damageNumber;
    [SerializeField] private PlayerHealth playerHealth;
    //Iframes are currently not implemented yet; player health is also not capped either, so health immediately plummets the moment they touch the enemy.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            DealDamage(); 
        }
    }
    void DealDamage()
    {
        playerHealth.currentHealth -= damageNumber; 
    }
}
