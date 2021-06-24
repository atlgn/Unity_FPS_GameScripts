using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpPad : MonoBehaviour
{
    public bool nowjump = false;
    public bool _isPlayerInside;
   public GameObject player;

    public float jumpHeight =1.0f;

   

    private void OnTriggerEnter(Collider other)
    {
        _isPlayerInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isPlayerInside = false;
    }


    private void LateUpdate()
        { 
Vector3 jump = player.transform.position;

 
        if (_isPlayerInside && !nowjump)
        {
          player.transform.DOLocalMoveY(jump.y + jumpHeight, 1f).SetEase(Ease.OutQuad).SetRelative(true).OnComplete( () => nowjump =true );
        }if(nowjump){
         nowjump = false;
        }

      }
  }
     
