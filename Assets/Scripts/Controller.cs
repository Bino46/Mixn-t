using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    PlayerInput controlAction;
    InputAction moveCamAction;
    Vector2 controlMovement;
    [SerializeField] Vector2 minMaxVerticalView;
    [SerializeField] float sensX;
    [SerializeField] float sensY;
    [SerializeField] float maxAcceleration;

    float xRotation;

    private void Awake()
    {
        controlAction = GetComponent<PlayerInput>();
        moveCamAction = controlAction.actions["MoveCam"];
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        moveCamAction.performed += MoveCam;
    }

    private void OnDisable()
    {
        moveCamAction.performed -= MoveCam;
    }

    void MoveCam(InputAction.CallbackContext ctx)
    {
        controlMovement = ctx.ReadValue<Vector2>();
        controlMovement.x = Mathf.Clamp(controlMovement.x, -maxAcceleration, maxAcceleration);
        controlMovement.y = Mathf.Clamp(controlMovement.y, -maxAcceleration, maxAcceleration);

        transform.Rotate(Vector3.up, controlMovement.x * Time.deltaTime * sensX);

        xRotation -= controlMovement.y * Time.deltaTime * sensY;
        xRotation = Mathf.Clamp(xRotation, minMaxVerticalView.x, minMaxVerticalView.y);

        Vector3 targetRotation = transform.eulerAngles;

        targetRotation.x = xRotation;
        targetRotation.z = 0;

        transform.eulerAngles = targetRotation;
    }
}