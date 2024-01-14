using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeContainer : MonoBehaviour
{
    public List<Ingredient> ingredients = new List<Ingredient>();
    [SerializeField] GameObject[] IngredientUI = new GameObject[3];
    [SerializeField] int index;
    [SerializeField] Vector3 yeetDir;
    [SerializeField] float yeetForce;
    [SerializeField] Fiole container;
    [SerializeField] GameObject fioleParent;
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
                // UIManager();
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

    void UIManager()
    {
        IngredientUI[index].GetComponent<Image>().sprite = ingredients[index].spriteIngredient;
    }

    void Mix()
    {
        string potionIndex = "";

        for (int i = 0; i < 3; i++)
        {
            potionIndex += ingredients[i].value.ToString();
        }

        fioleParent.SetActive(true);
        container.GetFunction(potionIndex);
    }

    void Yeet(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().AddForce(yeetDir * yeetForce);
    }

    public void Reset()
    {
        index = 0;
        fioleParent.SetActive(false);
        ingredients.RemoveRange(0, ingredients.Count);
    }
}
