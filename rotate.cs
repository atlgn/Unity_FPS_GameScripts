using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public Vector3 RotationVector;

    void Update(){
        transform.Rotate(RotationVector,Space.World);
    }

}