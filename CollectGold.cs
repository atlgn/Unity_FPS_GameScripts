using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectGold : MonoBehaviour
{
    public int Gold = 0;
    public Text text;

public void goldTake(){
    Gold =  1 + Gold ;

      text.text=Gold.ToString();

}
 
}
