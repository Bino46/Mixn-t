using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeContainer : MonoBehaviour
{
    [SerializeField] List<Ingredient> ingredients = new List<Ingredient>();
    [SerializeField] int index;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            Ingredient newIngr = other.gameObject.GetComponent<Ingredient>();
            if (index > 0)
            {
                for (int i = index; i >= 0; i--)
                {
                    if (newIngr.value > ingredients[i].value)
                    {
                        if (i == index - 1)
                            ingredients.Add(newIngr);
                        else
                            ingredients.Insert(i, newIngr);
                    }
                }
            }
            else
            {
                ingredients.Add(newIngr);
            }

            index++;
            other.gameObject.SetActive(false);

            if (index == 3)
            {
                ingredients.Sort();
                Mix();
            }
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
        //GetFunction(potionIndex);
    }

    void GetFunction(string index)
    {


        // switch (index)
        // {
        //     case 8:
        //         AggroRock();
        //         break;
        //     case 11:
        //         Nuke();
        //         break;
        //     case 15:
        //         UwU();
        //         break;
        //     case 16:
        //         Pixel();
        //         break;
        //     case 23:
        //         Frog();
        //         break;
        //     case 24:
        //         ScrewGravity();
        //         break;
        //     case 25:
        //         FloatRock();
        //         break;
        //     case 27:
        //         Moai();
        //         break;
        //     default:
        //         Debug.Log("fuck you");
        //         break;
        // }
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
