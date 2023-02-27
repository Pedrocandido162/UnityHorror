using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertEagle : MonoBehaviour
{

    [SerializeField] AudioClip audioShoot;
    [SerializeField] AudioSource audio;
    [SerializeField] AnimationClip shootAnim;
    [SerializeField] Animator animator;
   
    void Start()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)  && !audio.isPlaying)
        {
            animator.SetBool("InputLeft", true);
        }
        else
        {
            animator.SetBool("InputLeft", false);
        }

       }

    public void Shoot()
    {
        audio.clip = audioShoot;
        audio.Play();
    }
}
