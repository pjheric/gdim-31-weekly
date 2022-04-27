using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    //Simple singleton pattern to persist/appropriately destroy objects
    void Awake()
    {
        int numScenePersists = FindObjectsOfType<ScenePersist>().Length;
        if (numScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject); 
    }
    public void ResetScenePersist()
    {
        Destroy(gameObject); 
    }
}
