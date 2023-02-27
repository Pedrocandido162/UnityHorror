using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivedMove : MonoBehaviour
{
    public delegate void step();
    public static event step OnMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (OnMove != null)
            {
                OnMove();
            }
        }
    }
}
