using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class turretGun : MonoBehaviour
{ public Target target;
    public GameObject BulletPrefab;

    public Transform MuzzleTransform;

    public float BulletSpeed;
     
     public float FireRate = 10;
     private float lastFired = 10;
     public AudioSource firesound ;

     private void LateUpdate() {
                if (target.health > 0f )
                {
                     if (Time.time > lastFired){        
        if (Time.time > lastFired)
         {
             lastFired += FireRate;
             ShootBullet();
         }  } 
            
                }  
     void ShootBullet()
    {
        firesound.Play();
        //instantiate the bullet
        var bullet = Instantiate(BulletPrefab, MuzzleTransform.position, MuzzleTransform.rotation);

        // give it velocity
        bullet.GetComponent<Rigidbody>().velocity = MuzzleTransform.forward * BulletSpeed;
    }
}
}