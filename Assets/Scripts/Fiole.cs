using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Fiole : MonoBehaviour
{
    [SerializeField] List<Material> materials = new List<Material>();
    [SerializeField] List<string> index = new List<string>();
    Dictionary<string, Material> potionColor = new Dictionary<string, Material>();
    string effect;

    [Header("Rock")]
    [SerializeField] Transform origin;
    [SerializeField] GameObject rock;
    [SerializeField] Vector3 yeetDir;
    [SerializeField] float yeetForce;
    Animator animRock;
    Rigidbody bodyRock;
    BoxCollider colRock;

    private void Start()
    {
        animRock = rock.GetComponent<Animator>();
        bodyRock = rock.GetComponent<Rigidbody>();
        colRock = rock.GetComponent<BoxCollider>();

        for (int i = 0; i < index.Count; i++)
        {
            potionColor.Add(index[i].ToString(), materials[i]);
        }
        gameObject.SetActive(false);
    }
    public void GetFunction(string index)
    {
        effect = index;
        Debug.Log(effect);
        if (potionColor.ContainsKey(effect))
            gameObject.GetComponent<MeshRenderer>().material = potionColor[effect];
        else
            gameObject.GetComponent<MeshRenderer>().material = materials[materials.Count - 1];
    }

    void ApplyEffect()
    {
        switch (effect)
        {
            case "125":
                AggroRock();
                break;
            case "137":
                Nuke();
                break;
            case "438":
                UwU();
                break;
            case "268":
                Pixel();
                break;
            case "689":
                Frog();
                break;
            case "6711":
                ScrewGravity();
                break;
            case "6911":
                FloatRock();
                break;
            case "8910":
                Moai();
                break;
            default:
                Debug.Log("fuck you");
                break;
        }
    }

    [Button]
    public void Reset()
    {
        animRock.enabled = false;
        colRock.enabled = false;
        rock.transform.position = origin.position;
        bodyRock.velocity = Vector3.zero;
        bodyRock.useGravity = false;
    }

    #region Functions

    [Button]
    void AggroRock()
    {
        Debug.Log("Aggro rock");
    }

    [Button]
    void Nuke()
    {
        Debug.Log("Nuke");
    }

    [Button]
    void UwU()
    {
        Debug.Log("UwU");
    }

    [Button]
    void Pixel()
    {
        Debug.Log("Pixel");
    }

    [Button]
    void Frog()
    {
        Debug.Log("Frog");
    }

    [Button]
    void ScrewGravity()
    {
        Debug.Log("ScrewGravity");
        animRock.enabled = true;
        animRock.SetTrigger("gravity");
    }

    [Button]
    void FloatRock()
    {
        Debug.Log("FloatRock");
        colRock.enabled = true;
        bodyRock.useGravity = true;
        bodyRock.AddForce(yeetDir * 1000);
    }

    [Button]
    void Moai()
    {
        Debug.Log("Moai");
    }

    #endregion
}
