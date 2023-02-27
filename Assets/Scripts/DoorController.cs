using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    DialogueControl dialogueControl;
    ControlleCamera controlCam;
    bool pertoPorta;
    Animator animator;
    string teste;
    string comandoE= "Pressione (E) para abrir a porta.";
    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        dialogueControl = FindObjectOfType < DialogueControl>();
        controlCam= FindObjectOfType< ControlleCamera>();
        
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E)&&pertoPorta)
        {
            animator.SetBool("DoorOpen", true);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        pertoPorta = true;
        dialogueControl.ComandosDoor(comandoE);
        controlCam.SetpertoPorta(pertoPorta);
        }
        
 
    }
    private void OnTriggerExit(Collider other)
    {
        pertoPorta= false;
        if (other.gameObject.CompareTag("Player"))
        {
                dialogueControl.ComandosDoor(null);
           
        }
    }

    
       
    

   
}
