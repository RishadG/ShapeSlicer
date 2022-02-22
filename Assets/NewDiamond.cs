using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDiamond : MonoBehaviour
{
    public float reduce_val;
    public SkinnedMeshRenderer skinnedMeshrenderer;

    float reducer = 0;
    float reducer1 = 0;
    float reducer2 = 0;
    float reducer3 = 0;
    float reducer4 = 0;
    bool cut_top_left = false;
    bool cut_top_right = false;
    bool cut_bottom_left = false;
    bool cut_bottom_right = false;
    bool cut_top = false;

    public GameObject woodFX;
    public ParticleSystem woodParticle;


    public GameObject top_left_wooden_particle;
    public GameObject top_right_wooden_particle;
    public GameObject bottom_right_wooden_particle;
    public GameObject bottom_left_wooden_particle;
    public GameObject top_wooden_particle;



    public float limit;
    // Start is called before the first frame update
    void Start()
    {
        top_left_wooden_particle.SetActive(false);
        top_right_wooden_particle.SetActive(false);
        bottom_right_wooden_particle.SetActive(false);
        bottom_left_wooden_particle.SetActive(false);
        top_wooden_particle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (cut_top_left)
        {
            reducer += reduce_val;
            setBlendWeight(3, reducer);
        }
        else if (cut_top_right)
        {
            reducer1 += reduce_val;
            setBlendWeight(2, reducer1);
        }
        else if (cut_bottom_left)
        {
            reducer2 += reduce_val;
            setBlendWeight(1, reducer2);
        }
        else if (cut_bottom_right)
        {
            reducer3 += reduce_val;
            setBlendWeight(0, reducer3);
        }
        else if (cut_top)
        {
            reducer4 += reduce_val;
            setBlendWeight(4, reducer4);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collide");
      
        if (other.gameObject.tag == "Cut_top_left")
        {
            cut_top_left = true;
            top_left_wooden_particle.SetActive(true);
        }
        if (other.gameObject.tag == "Cut_top_right")
        {
            cut_top_right = true;
            top_right_wooden_particle.SetActive(true);
        }
        if (other.gameObject.tag == "Cut_bottom_left")
        {
            cut_bottom_left = true;
            bottom_left_wooden_particle.SetActive(true);
        }
        if (other.gameObject.tag == "Cut_bottom_right")
        {
            cut_bottom_right = true;
            bottom_right_wooden_particle.SetActive(true);
        }
        if (other.gameObject.tag == "Cut_top")
        {
            cut_top = true;
            top_wooden_particle.SetActive(true);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        woodParticle.Stop();

        if (other.gameObject.tag == "Cut_top_left")
        {
            cut_top_left = false;
            top_left_wooden_particle.SetActive(false);
        }
        if (other.gameObject.tag == "Cut_top_right")
        {
            cut_top_right = false;
            top_right_wooden_particle.SetActive(false);
        }
        if (other.gameObject.tag == "Cut_bottom_left")
        {
            cut_bottom_left = false;
            bottom_left_wooden_particle.SetActive(false);
        }
        if (other.gameObject.tag == "Cut_bottom_right")
        {
            cut_bottom_right = false;
            bottom_right_wooden_particle.SetActive(false);
        }
        if (other.gameObject.tag == "Cut_top")
        {
            cut_top = false;
            top_wooden_particle.SetActive(false);
        }
    }
    void setBlendWeight(int number, float weight)
    {
        if (weight < limit)
        {
            skinnedMeshrenderer.SetBlendShapeWeight(number, weight);
        }


    }
}
