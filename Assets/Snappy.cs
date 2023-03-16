using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Snappy : MonoBehaviour
{

    public AudioMixerSnapshot groupA;
    public AudioMixerSnapshot groupB;
    public float transtionTime = 1.5f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            groupA.TransitionTo(transtionTime);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            groupB.TransitionTo(transtionTime);
        }
    }
}
