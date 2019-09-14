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
            //Set the main Color of the Material to green
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.green);

            //Find the Specular shader and change its Color to red
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor", Color.red);
        }
        else
        {
            //Set the main Color of the Material to green
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.blue);

            //Find the Specular shader and change its Color to red
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor", Color.blue);
        }
    }
}
