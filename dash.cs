using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dash : MonoBehaviour
{
   public float speed = 10f;

     public float dashLength = 0.15f;
     public float dashSpeed = 100f;
     public float dashResetTime = 1f;
 
     public CharacterController characterController;
    
     private Vector3 dashMove;
     private float dashing = 0f;
     private float dashingTime = 0f;
     private bool canDash = true;
     private bool dashingNow = false;
     private bool dashReset = true;
     
 [SerializeField] private AudioClip dashSound;  
 private AudioSource audioSource;
 void Start(){
     audioSource =  GetComponent<AudioSource>();
 }
     void Update()
     {
         float moveX = Input.GetAxis("Horizontal");
         float moveZ = Input.GetAxis("Vertical");
 
         Vector3 move = transform.right * moveX + transform.forward * moveZ;
 
         if (move.magnitude > 1)
         {
             move = move.normalized;
         }
 
 
         if (Input.GetKeyDown(KeyCode.LeftShift) && dashing < dashLength && dashingTime < dashResetTime && dashReset == true && canDash == true)
         {
             dashMove = move;
             canDash = false;
             dashReset = false;
             dashingNow = true;
             audioSource.clip = dashSound;
             audioSource.PlayOneShot(audioSource.clip);
         }
     }
     void LateUpdate(){
 
         if (dashingNow == true && dashing < dashLength)
         {
             characterController.Move(dashMove * dashSpeed * Time.deltaTime);
             dashing += Time.deltaTime;
         }
 
         if (dashing >= dashLength)
         {
             dashingNow = false;
         }
 
         if (dashReset == false)
         {
             dashingTime += Time.deltaTime;
         }
 
         if (characterController.isGrounded && canDash == false && dashing >= dashLength)
         {
             canDash = true;
             dashing = 0f;
         }
 
         if (dashingTime >= dashResetTime && dashReset == false)
         {
             dashReset = true;
             dashingTime = 0f;
         }
     }
 }