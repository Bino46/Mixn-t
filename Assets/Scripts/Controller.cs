using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    PlayerInput controlAction;

    [Header("Camera")]
    InputAction moveCamAction;
    Vector2 controlMovement;
    [SerializeField] Vector2 minMaxVerticalView;
    [SerializeField] float sensX;
    [SerializeField] float sensY;
    [SerializeField] float maxAcceleration;
    float xRotation;

    [Header("Raycast")]
    [SerializeField] Camera mainCam;
    InputAction clicRay;
    InputAction clicPos;
    [SerializeField] Transform moveObjectPos;
    GameObject currObj = null;
    Vector3 mousePos;
    Vector3 worldPos;
    float camDist = 10;
    bool lockObject;

    private void Awake()
    {
        controlAction = GetComponent<PlayerInput>();
        //moveCamAction = controlAction.actions["MoveCam"];
        clicPos = controlAction.actions["ClickPos"];
        clicRay = controlAction.actions["ClicRay"];
        mainCam = Camera.main;
    }

    private void OnEnable()
    {
        //moveCamAction.performed += MoveCam;
        clicRay.performed += GetItem;
        clicPos.performed += GetMousePos;
    }

    private void OnDisable()
    {
        //moveCamAction.performed -= MoveCam;
        clicRay.performed -= GetItem;
        clicPos.performed -= GetMousePos;
    }

    private void Update()
    {
        if (currObj != null && !lockObject)
        {
            //Vector3 newPos = mainCam.ScreenToWorldPoint(clicPos.ReadValue<Vector2>());
            currObj.transform.position = moveObjectPos.transform.position;
            moveObjectPos.transform.position = worldPos;
        }
    }

    // void MoveCam(InputAction.CallbackContext ctx)
    // {
    //     controlMovement = ctx.ReadValue<Vector2>();
    //     controlMovement.x = Mathf.Clamp(controlMovement.x, -maxAcceleration, maxAcceleration);
    //     controlMovement.y = Mathf.Clamp(controlMovement.y, -maxAcceleration, maxAcceleration);

    //     transform.Rotate(Vector3.up, controlMovement.x * Time.deltaTime * sensX);

    //     xRotation -= controlMovement.y * Time.deltaTime * sensY;
    //     xRotation = Mathf.Clamp(xRotation, minMaxVerticalView.x, minMaxVerticalView.y);

    //     Vector3 targetRotation = transform.eulerAngles;

    //     targetRotation.x = xRotation;
    //     targetRotation.z = 0;

    //     transform.eulerAngles = targetRotation;
    // }

    void GetItem(InputAction.CallbackContext ctx)
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
                    currObj.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }
        else
        {
            currObj.GetComponent<Rigidbody>().useGravity = true;
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