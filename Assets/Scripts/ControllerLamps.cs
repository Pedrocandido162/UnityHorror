using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ControllerLamps : MonoBehaviour
{
    private Light light;
    [SerializeField] private GameObject zumbi;
    LampsScene scene;
    // Start is called before the first frame update
    void Start()
    {
        light =GetComponent<Light>();
        scene = FindObjectOfType<LampsScene>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Onlamp()
    {
        light.enabled = true;  
    }
    public void OffLamp()
    {
        Destroy(zumbi);
        light.enabled = false;
        scene.OnlampsScene();
    }
}
