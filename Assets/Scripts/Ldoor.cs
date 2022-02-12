using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ldoor : MonoBehaviour
{
    public float x;
    private void OnTriggerEnter(Collider other)
    {
        transform.Translate(x,0,0);
        
    }
    
}
