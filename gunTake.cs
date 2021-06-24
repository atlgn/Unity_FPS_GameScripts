using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunTake : MonoBehaviour
{
    public AudioSource takeGunSound;
    public int gunId;
 private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                takeGunSound.Play();
            
            }
    }
    
}
