using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collision))]
public class LiveManager : MonoBehaviour {
    float live;
    Renderer rend;
    // Use this for initialization
    void Start () {
        live = 100;
        //Fetch the Renderer from the GameObject
        rend = GetComponent<Renderer>();

        //Set the main Color of the Material to green
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.green);

        //Find the Specular shader and change its Color to red
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.red);
    }
	
	// Update is called once per frame
	void Update () {
        if(live < 60) {
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.yellow);
        }
        else if(live < 30) {
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.red);
        }
        if (live <= 0)
            Destroy(transform.gameObject);
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Bullet")
            live -= 10;
    }
}
