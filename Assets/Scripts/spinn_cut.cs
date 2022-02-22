using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinn_cut : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem Cube_breaking;
    void Start()
    {
        Cube_breaking.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0,transform.rotation.y + 5,0);
    }

   private void OnTriggerEnter(Collider other)
    {
    	//Debug.Log("Fuck");
    	if(other.gameObject.tag == "Player"){

    		Cube_breaking.Play();
    	}

    }
   
   private void OnTriggerExit(Collider other)
    {
    	if(other.gameObject.tag == "Player"){
    		Cube_breaking.Stop();
    	}

    }



}
