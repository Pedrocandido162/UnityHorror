using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raio : MonoBehaviour
{
    // Start is called before the first frame update
    public float tempoRaio;
    float contador;
    Light light;
    void Start()
    {
        light = GetComponent<Light>();
        InvokeRepeating("RaioOn", 5, tempoRaio);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (light.enabled)
        {
            contador += Time.deltaTime;
            if (contador >= 1f)
            {
                light.enabled = false;
                contador = 0.7f;
            }
                
        }
    }
    void RaioOn()
    {
        light.enabled = true;
       
    }
}
