using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
      public void startGame()
    {
        SceneManager.LoadScene(1);
    }

       public void ExitGame()
    {
        Application.Quit(); 
    }
}
