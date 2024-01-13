using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScene : MonoBehaviour
{
    [SerializeField] GameObject ingrParent;
    GameObject[] objectPrefabs = new GameObject[11];
    [SerializeField] GameObject posParent;
    Transform[] objectPos = new Transform[11];
    [SerializeField] bool reset;

    private void Start()
    {
        for (int i = 0; i < ingrParent.transform.childCount; i++)
        {
            objectPrefabs[i] = ingrParent.transform.GetChild(i).gameObject;
            objectPos[i] = posParent.transform.GetChild(i);
        }
    }

    private void Update()
    {
        if (reset)
        {
            ResetObjects();
            reset = false;
        }

    }

    void ResetObjects()
    {
        for (int i = 0; i <= objectPrefabs.Length - 1; i++)
        {
            if (!objectPrefabs[i].activeSelf)
            {
                objectPrefabs[i].SetActive(true);
            }

            objectPrefabs[i].transform.position = objectPos[i].position;
            objectPrefabs[i].transform.rotation = objectPos[i].rotation;
        }
    }
}
