using UnityEngine;

public class Target : MonoBehaviour
{

public float health = 50f;

 private void Start() {
 
 }
public void TakeDmage(float amount){
 health-=amount;
 if(health<=0f){
     Die();

 }

}
 void Die(){
     Destroy(gameObject);

 }

}
