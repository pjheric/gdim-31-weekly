using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ClearMenu : MonoBehaviour
{
   public void BackToStart()
   {
       SceneManager.LoadScene("Start Menu"); 
   }
   public void QuitGame()
   {
       Application.Quit();
   }
}
