using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runnermovement : MonoBehaviour
{
    Rigidbody rb;
    public float forwardMoveSpeed = 10f;
    public float LRMoveSpeed = 0.45f;
    Vector3 moveto;
    private float startPos;
    private float currentPos;
    public static bool simulateMouseWithTouches;
    private Ray screenRay;
    RaycastHit hitInfo;
    private Camera mainCam;
    // Start is called before the first frame update
    bool finish = false;
    public GameObject pic;
    public GameObject confetti;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = Camera.main;
        confetti.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        doFingerTouch();
        doMouseTouch();
        // Disable keyboard movement or the other 2 wont work!!!
        doKeyboardMovement();
    }

    private void FixedUpdate()
    {   if(!finish){
        transform.Translate(Vector3.forward * forwardMoveSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.forward * (LRMoveSpeed * currentPos) * Time.deltaTime);
        }else{

        }
    }

    private float getMousePosition()
    {
        //int layerMask = 1 << 8;
        screenRay = mainCam.ScreenPointToRay(Input.mousePosition);

        bool ishit = Physics.Raycast(screenRay, out hitInfo, 100);
        if (ishit)
        {
            //  Debug.Log(hitInfo.point);
            Debug.Log(hitInfo.collider.name);
            Debug.Log("HIt At:" + hitInfo.point.z);
            return hitInfo.point.z;
        }
        return 0;
    }

    private void doFingerTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    moveto = touch.position;
                    startPos = touch.position.x;
                    Debug.Log(touch.position);
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    ///  Debug.Log(touch.position);
                    Debug.Log(touch.deltaPosition);
                    currentPos = touch.deltaPosition.x;
                    //touch.deltaPosition();
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    break;
            }
        }
    }
    private void doMouseTouch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = getMousePosition();
            Debug.Log(startPos);
        }
        if (Input.GetMouseButton(0))
        {
            currentPos = startPos - getMousePosition() * 6;
        }
        if (Input.GetMouseButtonUp(0))
        {
            currentPos = 0;
        }

    }
    private void doKeyboardMovement()
    {
        if (Input.GetKey("d"))
        {
            currentPos += 1 ;
        }
        else if (Input.GetKey("a"))
        {
            currentPos -= 1 ;
        }
        else
        {
            currentPos = 0;
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "finish"){
            Invoke("Delay", 1.0f);
        }
    }

    void Delay(){
        finish = true;
        pic.SetActive(false);
        confetti.SetActive(true);
    }


}
