using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCrack : MonoBehaviour
{
    
public float health = 10f;
public void TakeDmage(float amount){
 health-=amount;
 if(health<=0f){
     Crack();

 }
 }
 void Crack(){
     Destroy(gameObject);
 }
}

