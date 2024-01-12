using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeContainer : MonoBehaviour
{
    [SerializeField] Ingredient[] ingredients = new Ingredient[3];
    [SerializeField] int index;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            ingredients[index] = other.gameObject.GetComponent<Ingredient>();
            other.gameObject.SetActive(false);
            index++;

            if (index == 3)
            {
                Mix();
            }
        }
    }

    void Mix()
    {
        int potionIndex = 0;

        for (int i = 0; i < 3; i++)
        {
            potionIndex += ingredients[i].value;
        }

        GetFunction(potionIndex);
    }

    void GetFunction(int index)
    {
        switch (index)
        {
            case 1:
                break;
        }
    }

    #region Functions

    #endregion
}
