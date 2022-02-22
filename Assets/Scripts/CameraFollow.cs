using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float posY = 4.6f, posZ = 0;
    public bool finish=false;
    public static CameraFollow instance;
    // Start is called before the first frame update
    // Update is called once per frame
    public void LateUpdate()
    {
        normalCam();
    }

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
    }

    public void normalCam()
    {
        if(!finish)
        {
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, target.position.z + offset.z);
            transform.position = desiredPosition;

        }
        else
        {
            
            Vector3 desiredPosition = new Vector3(transform.position.x, 5.21f, target.position.z + offset.z);
            transform.position = Vector3.Lerp(transform.position,desiredPosition,Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(2.63f, transform.rotation.y, transform.rotation.z), Time.deltaTime));
            transform.rotation = Quaternion.Euler(2.63f, transform.rotation.y, transform.rotation.z);
        }


    }
    
}
