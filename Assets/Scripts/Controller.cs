using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    PlayerInput controlAction;

    [Header("Raycast")]
    [SerializeField] Camera mainCam;
    InputAction clicRay;
    InputAction clicPos;
    [SerializeField] Transform moveObjectPos;
    GameObject currObj = null;
    Vector3 mousePos;
    Vector3 worldPos;
    float camDist = 10;
    float isClicking;
    [SerializeField] Animator potion;

    [Header("Momuntum")]
    InputAction moveCamAction;
    Vector2 controlMovement;
    Vector2 checkMouseSpeed;
    float currXSpeed;
    float currYSpeed;
    [SerializeField] Vector2 minMouseSpeed;
    [SerializeField] float maxTimer;
    float timer;

    private void Awake()
    {
        controlAction = GetComponent<PlayerInput>();
        //moveCamAction = controlAction.actions["MoveCam"];
        clicPos = controlAction.actions["ClickPos"];
        clicRay = controlAction.actions["ClicRay"];
        moveCamAction = controlAction.actions["MoveCam"];
        mainCam = Camera.main;
        timer = maxTimer;
    }

    private void OnEnable()
    {
        //moveCamAction.performed += MoveCam;
        //clicRay.performed += GetItem;
        clicPos.performed += GetMousePos;
    }

    private void OnDisable()
    {
        //moveCamAction.performed -= MoveCam;
        // clicRay.performed -= GetItem;
        clicPos.performed -= GetMousePos;
    }

    private void Update()
    {
        if (currObj != null)
        {
            currObj.transform.position = moveObjectPos.transform.position;
            moveObjectPos.transform.position = worldPos;
        }

        isClicking = clicRay.ReadValue<float>();
        GetItem();

        AddMomuntum();
    }

    void AddMomuntum()
    {
        timer -= Time.deltaTime;

        checkMouseSpeed = moveCamAction.ReadValue<Vector2>();
        checkMouseSpeed.x = Mathf.Abs(checkMouseSpeed.x);
        checkMouseSpeed.y = Mathf.Abs(checkMouseSpeed.y);

        if (checkMouseSpeed.x > minMouseSpeed.x || checkMouseSpeed.y > minMouseSpeed.y)
        {
            if (timer <= 0 || currXSpeed < checkMouseSpeed.x || currYSpeed < checkMouseSpeed.y)
            {
                controlMovement = moveCamAction.ReadValue<Vector2>();

                currXSpeed = Mathf.Abs(controlMovement.x);
                currYSpeed = Mathf.Abs(controlMovement.y);

                timer = maxTimer;
            }
        }
        else
        {
            controlMovement = Vector2.zero;
        }
    }

    void GetItem()
    {
        if (isClicking == 1)
        {
            if (currObj == null)
            {
                Ray ray = mainCam.ScreenPointToRay(mousePos);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 3))
                {
                    Debug.DrawRay(ray.origin, ray.direction * 15, Color.yellow);
                    if (hit.collider.gameObject != null)
                    {
                        currObj = hit.collider.gameObject;
                        moveObjectPos.transform.position = currObj.transform.position;
                        camDist = currObj.transform.position.z;
                        //currObj.GetComponent<Rigidbody>().useGravity = false;
                    }
                }

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 6))
                {
                    Debug.DrawRay(ray.origin, ray.direction * 15, Color.red);
                    if (hit.collider.gameObject != null)
                    {
                        potion.SetTrigger("yeet");
                    }
                }
            }
        }
        else if (currObj != null)
        {
            //currObj.GetComponent<Rigidbody>().useGravity = true;
            currObj.GetComponent<Rigidbody>().velocity = controlMovement;
            currObj = null;
        }
    }

    void GetMousePos(InputAction.CallbackContext ctx)
    {
        mousePos.x = clicPos.ReadValue<Vector2>().x;
        mousePos.y = clicPos.ReadValue<Vector2>().y;
        mousePos.z = camDist;
        worldPos = mainCam.ScreenToWorldPoint(mousePos);
    }
}