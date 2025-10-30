using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
：
*/
public class Expolsion : MonoBehaviour
{

    private float survivalTime = 0.167f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, survivalTime);
    }



}
