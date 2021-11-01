using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class Health : MonoBehaviour
{
    [SerializeField] GameObject healthPrefab;
    [SerializeField] GameObject emptyHealthPrefab;

    public void DrawHealth(int health, int maxHealth)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject); 
        }
        for(int i = 0; i < maxHealth; i++)
        {
            if(i + 1 <= health)
            {
                GameObject heart = Instantiate(healthPrefab, transform.position, Quaternion.identity);
                heart.transform.parent = transform; 
            }
            else
            {
                GameObject heart = Instantiate(emptyHealthPrefab, transform.position, Quaternion.identity);
                heart.transform.parent = transform; 
            }
        }
    }
}
