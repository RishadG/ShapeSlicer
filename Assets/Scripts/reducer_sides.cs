using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reducer_sides : MonoBehaviour
{
    // Start is called before the first frame update
    public SkinnedMeshRenderer skinnedMeshrenderer;
    public float reduce_val;
    public string name;
    bool cut;
   float reducer = 0;
   public GameObject cube_particles;
   public GameObject destroy_object;
   public BoxCollider m_Collider;
   public int limit;

   public GameObject leftside_Particle;
   public GameObject rightside_Particle;
   public GameObject smoke_left;
   public GameObject smoke_right;

    void Start()
    {
        //cube_particles.SetActive(false);
        leftside_Particle.SetActive(false);
        rightside_Particle.SetActive(false);
        smoke_left.SetActive(false);
        smoke_right.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(cut){
        	reducer += reduce_val;
        	skinnedMeshrenderer.SetBlendShapeWeight(0, reducer);
        	//cube_particles.SetActive(true);
        	//Debug.Log(reducer);
        	//m_Collider.size = new Vector3(reducer, m_Collider.size.y, m_Collider.size.z);
        	if(reducer >= limit){
        		//Destroy(destroy_object);
        		destroy_object.SetActive(false);
        		cut = false;
        		//cube_particles.SetActive(false);
        	}
        }
    }

     private void OnTriggerEnter(Collider other)
    {
    	//Debug.Log("collide");
    	// if(other.gameObject.tag == "Cutter_down_left" || other.gameObject.tag == "Cutter_down_right"){
    	// 	    Debug.Log("collide");
    	// 		cut = true;
    	// }

    	if(other.gameObject.tag == "Cutter_down_left"){
    		leftside_Particle.SetActive(true);
    		smoke_left.SetActive(true);
    		cut = true;
    	}

    	if(other.gameObject.tag == "Cutter_down_right"){
    		rightside_Particle.SetActive(true);
    		smoke_right.SetActive(true);
    		cut = true;
    	}

    	
    	
    }

     private void OnTriggerExit(Collider other)
    {
    	if(other.gameObject.tag == "Cutter_down_left"){
    		leftside_Particle.SetActive(false);
    		smoke_left.SetActive(false);

    		cut = false;
    	}

    	if(other.gameObject.tag == "Cutter_down_right"){
    		rightside_Particle.SetActive(false);
    		smoke_right.SetActive(false);
    		cut = false;
    	}

    }


}
