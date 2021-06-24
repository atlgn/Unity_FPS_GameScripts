using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
  private Animator anim;
    void Start()
    {
         anim = this.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
       anim.SetBool("idle", false);
            anim.SetBool("show", true);
    }
          private void OnTriggerExit(Collider other) {
            anim.SetBool("show", false);
          }
        }
  
