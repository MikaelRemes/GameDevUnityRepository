using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public bool boxBlocking;
    
    void OnTriggerStay(Collider other)
    {
        if(other.tag.Equals("Box"))
        {
            boxBlocking = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Box"))
        {
            boxBlocking = false;
        }
    }

    private void Update()
    {
        //Fetch the Renderer from the GameObject
        Renderer rend = GetComponent<Renderer>();
        
        if (boxBlocking)
        {
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", new Color(0f,1f,0f,0.4f));
            
            rend.material.shader = Shader.Find("Transparent/Diffuse");
            rend.material.SetColor("_TransColor", new Color(0f, 1f, 0f, 0.4f));
        }
        else
        {
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", new Color(0f, 0f, 1f, 0.4f));

            rend.material.shader = Shader.Find("Transparent/Diffuse");
            rend.material.SetColor("_TransColor", new Color(0f, 0f, 1f, 0.4f));
        }
    }
}
