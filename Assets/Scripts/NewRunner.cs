
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class NewRunner : MonoBehaviour
{
    private TouchControls touchControls;
    private Vector2 DeltaTouch;
    public float forwardMoveSpeed = 10f;
    public float LRMoveSpeed = 0.45f;
    public GameObject pic;
    public GameObject confetti;
    public GameObject woodChipsPrefab;
    private bool FirstFinish = true;
    public bool finish = false;
    public static NewRunner instance;
    public GameObject ShapeToBurst;
    public GameObject BlendShape;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
        TouchSimulation.Enable();

    }
    private void OnDisable()
    {
        touchControls.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        touchControls.Touch.TouchInput.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchInput.canceled += ctx => EndTouch(ctx);


    }
    void StartTouch(InputAction.CallbackContext context)
    {
    //    Debug.Log(context.ReadValue<float>());
     //   Debug.Log(touchControls.Touch.TouchPosition.ReadValue<Vector2>());
    }
    void EndTouch(InputAction.CallbackContext context)
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Debug.Log(touchControls.Touch.TouchInput.ReadValue<UnityEngine.TouchPhase>());    
        DeltaTouch = touchControls.Touch.TouchDelta.ReadValue<Vector2>();

        if (DeltaTouch != Vector2.zero)
        {
            //    if(DeltaTouch.x)
          //  Debug.Log(DeltaTouch.x);


        }
        if(!finish)
        {
            transform.Translate(Vector3.forward * forwardMoveSpeed * Time.deltaTime, Space.World);
            transform.Translate(Vector3.right * (LRMoveSpeed * DeltaTouch) * Time.deltaTime);
        }
        else
        {
            if(FirstFinish)
            {
                //confetti.transform.position = this.transform.position;
                confetti.SetActive(true);
                ShapeToBurst.SetActive(true);
                BlendShape.SetActive(false);
            }
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        finish = true;
        if (other.gameObject.tag == "finish")
        {
            Invoke("Delay", 1.0f);
        }
    }
    void Delay()
    {
        finish = true;
        pic.SetActive(false);
        confetti.SetActive(true);
    }
}
