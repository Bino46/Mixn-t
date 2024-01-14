using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScene : MonoBehaviour
{
    [SerializeField] GameObject ingrParent;
    [SerializeField] GameObject[] objectPrefabs = new GameObject[11];
    [SerializeField] GameObject posParent;
    [SerializeField] Transform[] objectPos = new Transform[11];
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            ResetOneObject(other.gameObject);
        }
    }

    public void ResetObjects()
    {
        Rigidbody rb;
        for (int i = 0; i <= objectPrefabs.Length - 1; i++)
        {
            if (!objectPrefabs[i].activeSelf)
            {
                objectPrefabs[i].SetActive(true);
            }

            rb = objectPrefabs[i].GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            objectPrefabs[i].transform.position = objectPos[i].position;
            objectPrefabs[i].transform.rotation = objectPos[i].rotation;
        }

        RecipeContainer._instance.Reset();
    }

    void ResetOneObject(GameObject go)
    {
        int i = go.GetComponent<Ingredient>().value - 1;
        objectPrefabs[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
        objectPrefabs[i].transform.position = objectPos[i].position;
        objectPrefabs[i].transform.rotation = objectPos[i].rotation;
    }
}
