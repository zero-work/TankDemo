using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
：
*/
public class Barriar : MonoBehaviour
{
    public AudioClip barriarClip;


    public void PlayAudio() 
    {
        AudioSource.PlayClipAtPoint(barriarClip, transform.position);
    }
}
