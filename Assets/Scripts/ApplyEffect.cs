using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem splash;
    public void Apply()
    {
        Fiole._instance.ApplyEffect();
        GetComponent<MeshRenderer>().enabled = false;
        GameObject childPot = transform.GetChild(0).gameObject;
        childPot.GetComponent<MeshRenderer>().enabled = false;
        splash.Play();
    }
}
