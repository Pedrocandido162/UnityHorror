using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActivedTimeline : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] PlayableDirector playTimeline;

   
    void Start()
    {
      
        

    }

    // Update is called once per frame
    void Update()
    {
       /* if (playTimeline.  ==true)
        {
            ActivedMove.SetActive(false);
        }
        else
        {
            ActivedMove.SetActive(true);
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playTimeline.Play();
            Destroy(gameObject);
            
        }
    }
    


}
