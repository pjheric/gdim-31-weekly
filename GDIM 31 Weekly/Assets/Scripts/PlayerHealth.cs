using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Health healthMeter; 
    void Start()
    {
        currentHealth = maxHealth; 
    }
    //Updating this every frame is costly, but I will optimize later.
    void Update()
    {
        healthMeter.DrawHealth(currentHealth, maxHealth); 
    }
}
