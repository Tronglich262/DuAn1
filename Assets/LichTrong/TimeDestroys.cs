using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroys : MonoBehaviour
{
    public float Time;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,Time);
    }

 
}   
