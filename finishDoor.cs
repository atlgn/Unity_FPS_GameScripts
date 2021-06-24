using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishDoor : MonoBehaviour
{
   
   public CollectGold totalGold;
   public dotDoorOpen toggleDor;
  
    public void checkGold(){
  
  if (totalGold.Gold >= 5)
        {
            toggleDor.ToggleDoor();
        }
    }

    
    
      
}
