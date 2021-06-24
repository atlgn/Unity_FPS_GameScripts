using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScreen : MonoBehaviour
{
   public GameObject[] ShouldClose;
   public GameObject DeathCam;
    void Start()
    {
   Time.timeScale = 0f;

   foreach (GameObject item in ShouldClose)
   {
       item.SetActive(false);
   }


    DeathCam.SetActive(true);
      Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
