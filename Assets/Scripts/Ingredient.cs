using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public int value;
    public Sprite spriteIngredient;

    [SerializeField] Vector3 centerOfMass2;

    private void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass2;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position + transform.rotation * centerOfMass2, 0.1f);
    }
}
