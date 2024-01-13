using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Unity.Mathematics;

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
    [SerializeField] Mesh moai;
    [SerializeField] Mesh phrog;
    Mesh kayou;
    Animator animRock;
    Rigidbody bodyRock;
    BoxCollider colRock;
    MeshFilter meshRock;
    MeshRenderer renderRock;
    [SerializeField] Color rainbow;
    bool isRainbowing;
    float hValue;

    void Start()
    {
        animRock = rock.GetComponent<Animator>();
        bodyRock = rock.GetComponent<Rigidbody>();
        colRock = rock.GetComponent<BoxCollider>();
        meshRock = rock.GetComponent<MeshFilter>();
        kayou = meshRock.mesh;
        renderRock = rock.GetComponent<MeshRenderer>();

        for (int i = 0; i < index.Count; i++)
        {
            potionColor.Add(index[i].ToString(), materials[i]);
        }
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (hValue >= 0.96)
            hValue = 0;

        hValue += Time.deltaTime * 0.2f;

        rainbow = Color.HSVToRGB(hValue, 1, 1);

        materials[8].SetColor("_DarkColor", rainbow);
        materials[8].SetColor("_LightColor", rainbow);

    }
    public void GetFunction(string index)
    {
        effect = index;
        Debug.Log(effect);
        if (potionColor.ContainsKey(effect))
            gameObject.GetComponent<MeshRenderer>().material = potionColor[effect];
        else
            gameObject.GetComponent<MeshRenderer>().material = materials[8];
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
            case "279":
                RGB();
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
        meshRock.mesh = kayou;
        renderRock.material = materials[10];
        rock.transform.rotation = quaternion.Euler(new Vector3(0, 55, 0));
        isRainbowing = false;
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
        renderRock.material = materials[9];
        meshRock.mesh = phrog;
        rock.transform.rotation = quaternion.Euler(new Vector3(0, 180, 0));
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
        bodyRock.AddForce(yeetDir * yeetForce);
    }

    [Button]
    void Moai()
    {
        meshRock.mesh = moai;
        Debug.Log("Moai");
    }
    [Button]
    void RGB()
    {
        isRainbowing = true;
        Debug.Log("RGB");
        renderRock.material = materials[8];
    }

    #endregion
}
