using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f; 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(LoadNextLevel()); 
        }

    }
    //Really just here for futureproofing
    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) //If last scene has been reached
            nextSceneIndex = 0; //Reset 
        FindObjectOfType<ScenePersist>().ResetScenePersist(); 
        SceneManager.LoadScene(nextSceneIndex);
    }    
}
