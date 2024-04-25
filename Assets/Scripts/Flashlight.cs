using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    public Light directionalLight;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Light>().enabled = true;
        directionalLight.GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
