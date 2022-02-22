using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoop_Out : MonoBehaviour
{
    // Start is called before the first frame update
    float reducer;
    float reducer2;
    float reducer3;
    float reducer4;
    public float reduce_val;
    public SkinnedMeshRenderer skinnedMeshrenderer;
    bool start_cutting;
    bool start_cutting_2;
    bool start_cutting_3;
    bool start_cutting_4;
    public float speed = 2;
    public GameObject character;

   // public Joystick joystick;

    float inc = 0;

    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
    	if(start_cutting){
    			reducer += reduce_val;
    			skinnedMeshrenderer.SetBlendShapeWeight(0, reducer);
    		}

        if(start_cutting_2){
            reducer2 += reduce_val;
            skinnedMeshrenderer.SetBlendShapeWeight(1, reducer2);
        }


        if(start_cutting_3){
            reducer3 += reduce_val;
            skinnedMeshrenderer.SetBlendShapeWeight(3, reducer3 * 2);
        }

        if(start_cutting_4){
            reducer4 += reduce_val;
            skinnedMeshrenderer.SetBlendShapeWeight(2, reducer4 * 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
    	//Debug.Log("Fuck");
    	if(other.gameObject.tag == "Cutter"){
             start_cutting = true;
    	}
        if(other.gameObject.tag == "Cutter_Right"){
             start_cutting_2 = true;
        }
        if(other.gameObject.tag == "Cutter_down_right"){
             start_cutting_3 = true;
        }
         if(other.gameObject.tag == "Cutter_down_left"){
             start_cutting_4 = true;
        }

    }


     private void OnTriggerExit(Collider other)
    {
    	if(other.gameObject.tag == "Cutter"){
    		start_cutting = false;
    	}
        if(other.gameObject.tag == "Cutter_Right"){
             start_cutting_2 = false;
        }

         if(other.gameObject.tag == "Cutter_down_right"){
             start_cutting_3 = false;
        }

         if(other.gameObject.tag == "Cutter_down_left"){
             start_cutting_4 = false;
        }

    }


}
