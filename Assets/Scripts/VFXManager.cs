using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] List<ParticleSystem> vfxList = new List<ParticleSystem>();
    public static VFXManager _instance;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    public void PlayVFXAtPos(int index, Transform pos)
    {
        vfxList[index].transform.position = pos.position;
        vfxList[index].transform.rotation = pos.rotation;
        vfxList[index].Play();
    }
}
