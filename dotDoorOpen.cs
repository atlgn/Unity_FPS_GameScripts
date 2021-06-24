using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class dotDoorOpen : MonoBehaviour
{

    public GameObject leftDoor;
    public GameObject rightDoor;

[SerializeField] private AudioClip[] doorSound;  
 private AudioSource audioSource;

    public bool DoorIsOpen;
void Start(){
     audioSource =  GetComponent<AudioSource>();
 }
    public void OpenDoor()
    {
        if (!DoorIsOpen)
        {
            audioSource.clip = doorSound[0];
             audioSource.PlayOneShot(audioSource.clip);
         
            leftDoor.transform.DOLocalMoveZ(-5.69f, 3.5f).SetEase(Ease.OutBack);
            rightDoor.transform.DOLocalMoveZ(2.64f, 3.5f).SetEase(Ease.OutBack);
            DoorIsOpen = true;
        }
    }

    public void CloseDoor()
    {
        if (DoorIsOpen)
        {
           audioSource.clip = doorSound[1];
             audioSource.PlayOneShot(audioSource.clip);
        
            leftDoor.transform.DOLocalMoveZ(-3.09f, 3.5f);
            rightDoor.transform.DOLocalMoveZ(-0.072f, 3.5f);
            DoorIsOpen = false;
   
        }
    }

    public void ToggleDoor()
    {
        if (DoorIsOpen)
        {
            Invoke("CloseDoor", 4.0f);
        }
        else
        {

            OpenDoor();
        }
    }


}
