using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;
    public GameObject HitParticleEffect;
    private void OnCollisionEnter(Collision other)
    {
        var health = other.gameObject.GetComponentInParent<Health>();

        if (health != null)
        {
            health.ChangeHealth(-Damage);
        }
        
        //create a particle effect
        GameObject bulletEffect = Instantiate(HitParticleEffect, transform.position, Quaternion.identity);
        
        // destroy the bullet
        Destroy(gameObject);
        Destroy(bulletEffect,1f);
    }
}