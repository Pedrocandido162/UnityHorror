using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificadorDeChao : MonoBehaviour
{
    public GameObject verificador;
    private Vector3 distanceCamera;
    public List<AudioClip> concretestep;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        distanceCamera = transform.position - verificador.transform.position;
        audio = GetComponent<AudioSource>();
        ControlleCamera.OnStep += playStep;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 location = new Vector3(verificador.transform.position.x, verificador.transform.position.y,
        verificador.transform.position.z);
        transform.position = location + distanceCamera;
    }
    void playStep()
    {
        AudioClip clip = concretestep[Random.Range(0, concretestep.Count)];
        audio.PlayOneShot(clip);
    }


}