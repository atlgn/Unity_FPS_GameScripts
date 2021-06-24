using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
     public bool IsPaused;
    public GameObject PauseMenuObj;
    public FirstPersonController Controller;
    public Gun Gun;



    private void Start()
    {
        // When the game starts unpause the game
        Unpause();
       
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReturnToGame()
    {
          
        Unpause();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
public void RestartLevel(){
   SceneManager.LoadScene(1);
}
    private void TogglePause()
    {
        if (IsPaused)
        {
            Unpause();
        }
        else
        {
            Pause();
        }
    }

    public void Unpause()
    {
        Controller.enabled  = true;
        Gun.enabled  = true;
        
        Time.timeScale = 1f;
        PauseMenuObj.SetActive(false);
        IsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
       Controller.enabled  = false;
        Gun.enabled  = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        PauseMenuObj.SetActive(true);
    
        IsPaused = true;
        
        // Freeze time
        Time.timeScale = 0f;
    }

    public void ExitGame()
    {
        Application.Quit(); 
    }

}
