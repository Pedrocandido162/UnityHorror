using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampsScene : MonoBehaviour
{
    [SerializeField] private GameObject lamps;
    [SerializeField] private GameObject lamps1;
    [SerializeField] private GameObject lamps2;
    [SerializeField] private GameObject lamps3;
    [SerializeField] private GameObject lamps4;
    [SerializeField] private GameObject lamps5;


    void Start()
    {
    
        
    }
    // Update is called once per frame
    void Update()
    {


    }
    public void OnlampsScene()
    {
        lamps.SetActive(true);
        lamps1.SetActive(true);
        lamps2.SetActive(true);
        lamps3.SetActive(true);
        lamps4.SetActive(true);
        lamps5.SetActive(true);


    }
}
