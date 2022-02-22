using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reduce_side3_var : MonoBehaviour
{
    // Start is called before the first frame update
      public SkinnedMeshRenderer skinnedMeshrenderer;
    public float reduce_val;
    public string name;
    bool cut;
   float reducer = 0;
   //public GameObject cube_particles;
   public BoxCollider m_Collider;
   public float limit;

   int total_counts;

    void Start()
    {
        //cube_particles.SetActive(false);
        total_counts = skinnedMeshrenderer.sharedMesh.blendShapeCount;
        //Debug.Log(total_counts);
    }

    // Update is called once per frame
    void Update()
    {
         if(cut){
        	Debug.Log(total_counts);
        	if(total_counts == 1){
        	reducer += reduce_val;
        	skinnedMeshrenderer.SetBlendShapeWeight(0, reducer);
        	}

        	if(total_counts == 2){
        	reducer += reduce_val;
        	skinnedMeshrenderer.SetBlendShapeWeight(0, reducer);
        	skinnedMeshrenderer.SetBlendShapeWeight(1, reducer);
        	}

        	if(total_counts == 3){
        	reducer += reduce_val;
        	skinnedMeshrenderer.SetBlendShapeWeight(0, reducer);
        	skinnedMeshrenderer.SetBlendShapeWeight(1, reducer);
        	skinnedMeshrenderer.SetBlendShapeWeight(2, reducer);
        	}

        	if(reducer >= limit){
        			cut = false;
        	}
        }
    }

       private void OnTriggerEnter(Collider other)
    {
    	//Debug.Log("collide");
    	if(other.gameObject.tag == "Cutter"){
    		   // Debug.Log("collide");
    			cut = true;
    	}
    }

     private void OnTriggerExit(Collider other)
    {
    	if(other.gameObject.tag == "Cutter"){
    			cut = false;
    			//cube_particles.SetActive(false);
    	}
    }




}
