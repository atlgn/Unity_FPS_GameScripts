using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public GameObject impactEffect;
    public float impactForce = 30f;

    RaycastHit hit;

    private Animator anim;

    public GameObject effect;

    public bool alreadyPlayed = false;

    private bool nowFire = false;
    [SerializeField] private AudioClip fireSound;
    private AudioSource audioSource;
    public AudioSource firstTake;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !alreadyPlayed && !nowFire)
        {
            this.GetComponent<CameraShake>().shakeDuration = 0.4f; // Camera Shake

            nowFire = true;
            shoot();
        }
    }
    void LateUpdate()
    {
        if (nowFire)
        {
            anim.SetBool("idle", false);
            anim.SetBool("fire", true);
        }
        else
        {
            nowFire = false;
        }

    }
    void shoot()
    {
        audioSource.clip = fireSound;
        audioSource.PlayOneShot(audioSource.clip);
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) //RayCast
        {
            // if distance long late explosion   
            if (hit.distance <= 8)
            { Invoke("impactgo", 0.2f); }

            else if (hit.distance <= 15)
            { Invoke("impactgo", 0.4f); }

            else if (hit.distance <= 25)
            { Invoke("impactgo", 0.5f); }

            else if (hit.distance <= 45)
            { Invoke("impactgo", 0.7f); }

            else
            { Invoke("impactgo", 0.8f); }
        }

    }

    void impactgo() // Impact Effect and Damage
    {
        Debug.Log("Name :" + hit.transform.name + "Distance :" + hit.distance);

        this.GetComponent<CameraShake>().shakeDuration = 0.15f;

        Target target = hit.transform.GetComponent<Target>();
        wallCrack wallCrack = hit.transform.GetComponent<wallCrack>();

        if (wallCrack != null)
        {
            wallCrack.TakeDmage(damage);
        }
        if (target != null)
        {
            target.TakeDmage(damage);
        }
        if (hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(-hit.normal * impactForce);
        }

        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        if (impactGO != null)
        {
            impactGO.GetComponent<AudioSource>().Play();
        }
        Destroy(impactGO, 2f);// Impact Effect Destroy Self
    }

    public void checkReload()//animation event
    {
        anim.SetBool("fire", false);
        anim.SetBool("idle", true);
        alreadyPlayed = false;
        nowFire = false;

    }
    public void fire() //animation event
    {
        if (!alreadyPlayed)
        {
            Explode();
            alreadyPlayed = true;
        }

    }

    void Explode() // Gun Fire Particle
    {

        effect.GetComponent<ParticleSystem>().Play();

    }
    void FirstTake()
    {
        firstTake.Play();
        StartCoroutine(firstTakeNoFire());


    }

    IEnumerator firstTakeNoFire()
    {
        firstTake.Play();
        alreadyPlayed = true;
        yield return new WaitForSeconds(2);    //Wait one frame
        alreadyPlayed = false;
    }
}