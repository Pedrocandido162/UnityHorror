using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMonster : MonoBehaviour
{
    // Start is called before the first frame update
    private DialogueControl dc;
    void Start()
    {
        dc= FindObjectOfType<DialogueControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dc.VillainAttack(3);
        }
    }
}
