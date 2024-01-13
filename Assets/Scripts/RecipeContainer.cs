using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeContainer : MonoBehaviour
{
    [SerializeField] List<Ingredient> ingredients = new List<Ingredient>();
    [SerializeField] int index;
    [SerializeField] Vector3 yeetDir;
    [SerializeField] float yeetForce;
    public static RecipeContainer _instance;

    private void Start()
    {
        _instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            if (index <= 2)
            {
                Ingredient newIngr = other.gameObject.GetComponent<Ingredient>();

                if (index > 0)
                {
                    if (newIngr.value > ingredients[index - 1].value)
                        ingredients.Add(newIngr);
                    else
                    {
                        if (ingredients.Count > 1)
                        {
                            if (newIngr.value > ingredients[index - 2].value)
                                ingredients.Insert(index - 1, newIngr);
                            else
                                ingredients.Insert(index - 2, newIngr);
                        }
                        else
                            ingredients.Insert(0, newIngr);
                    }
                }
                else
                    ingredients.Add(newIngr);

                index++;
                other.gameObject.SetActive(false);

                if (index == 3)
                {
                    Mix();
                }
            }
            else
                Yeet(other.gameObject);
        }
    }

    void Mix()
    {
        string potionIndex = "";

        for (int i = 0; i < 3; i++)
        {
            potionIndex += ingredients[i].value.ToString();
        }
        Debug.Log(potionIndex);
        GetFunction(potionIndex);
    }

    void Yeet(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().AddForce(yeetDir * yeetForce);
        Debug.Log("yeet " + obj.name);
    }

    public void Reset()
    {
        index = 0;
        ingredients.RemoveRange(0, ingredients.Count);
    }

    void GetFunction(string index)
    {

        switch (index)
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
