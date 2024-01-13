using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiole : MonoBehaviour
{
    [SerializeField] List<Material> materials = new List<Material>();
    [SerializeField] List<string> index = new List<string>();
    Dictionary<string, Material> potionColor;
    string effect;

    private void Start()
    {
        for (int i = 0; i < index.Count; i++)
        {
            potionColor.Add(index[i], materials[i]);
        }
    }
    public void GetFunction(string index)
    {
        effect = index;
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

    #region Functions

    void AggroRock()
    {
        Debug.Log("Aggro rock");
    }

    void Nuke()
    {
        Debug.Log("Nuke");
    }

    void UwU()
    {
        Debug.Log("UwU");
    }

    void Pixel()
    {
        Debug.Log("Pixel");
    }

    void Frog()
    {
        Debug.Log("Frog");
    }

    void ScrewGravity()
    {
        Debug.Log("ScrewGravity");
    }

    void FloatRock()
    {
        Debug.Log("FloatRock");
    }

    void Moai()
    {
        Debug.Log("Moai");
    }

    #endregion
}
