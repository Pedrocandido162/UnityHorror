using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarreiraLamp : MonoBehaviour
{
    DialogueControl dc;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        dc= FindObjectOfType<DialogueControl>();
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dc.Speech("Ta muito escuro. Não dá pra ir sem lanterna.", "SGT.Candido");
           

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            dc.Speech(null,"SGT.Candido");
        }
    }
}
