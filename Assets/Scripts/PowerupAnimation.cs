using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] idle;
    void Start()
    {
        StartCoroutine(Idle()); 
    }
    IEnumerator Idle()
    {
        int i = 0; 
        while (i < idle.Length)
        {
            spriteRenderer.sprite = idle[i];
            i++;
            yield return new WaitForSeconds(0.07f);
            yield return 0; 
        }
        StartCoroutine(Idle()); 
    }
}
