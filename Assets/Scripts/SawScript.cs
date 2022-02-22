using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    public GameObject startPoint, endPoint;
    private GameObject tempGameObject;
    public GameObject SawObject;
    public float moveSpeed = 1f;
    public float RotateSpeed = 1f;
    public GameObject Rotator;  
    // Start is called before the first frame update
    void Start()
    {
        SawObject.transform.position = startPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        SawObject.transform.position = Vector3.Lerp(SawObject.transform.position, endPoint.transform.position, Time.deltaTime * moveSpeed);
        float distance = Vector3.Distance(SawObject.transform.position, endPoint.transform.position);
       // Debug.Log(distance);
        if (Mathf.Abs(distance) < 1)
        {
            tempGameObject = startPoint;
            startPoint = endPoint;
            endPoint = tempGameObject;
        }
        Rotator.transform.Rotate(-RotateSpeed * Time.deltaTime, 0f, 0f);
    }
}
