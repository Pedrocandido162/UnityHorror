using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Shotgun : MonoBehaviour
{

    [Header("Repump")]
    [SerializeField] private AudioSource audioPump;
    [SerializeField] AudioClip repump;
    [Header("Shoot")]
    [SerializeField] private AudioSource audioShoot;
    [SerializeField]private AudioClip shoot;
    [SerializeField] private GameObject particleShoot;
    
    //Varias das balas contidas na arma
    int bullet;
    int Mag;
    int difençaBullet;

    //Eventos
    public delegate void Step();
    public static event Step OnShoot;

    //Animator
    private Animator animator;

    //Scrit Dialogue Control
    DialogueControl dialogueControl;
    
    // Start is called before the first frame update
    void Start()
    {
        audioPump= GetComponent<AudioSource>(); 
        animator= GetComponent<Animator>();
        dialogueControl=FindObjectOfType<DialogueControl>();
        
    }
    private void Update()
    {
        bullet = dialogueControl.setBullet();
        Mag=dialogueControl.setMag();
        if (Input.GetMouseButtonDown(0) && bullet>0)
        {
            animator.SetBool("PressFire", true);
            
            
        }
        else
        {
            animator.SetBool("PressFire", false);
        }
        if(Input.GetKey(KeyCode.R) || bullet==0)
        {
            if (bullet < 5)
            {
                difençaBullet = 5 - bullet;
                animator.SetBool("PressR", true);

            }
            
        }
       
    }
    

    public void Repump()
    {
        audioPump.clip= repump;
        audioPump.Play();
    }
    public void Shoot()
    {
        audioShoot.clip= shoot;
        audioShoot.Play();
        bullet--;
        dialogueControl.GetBullets(bullet, Mag);
        particleShoot.SetActive(true);
        if (OnShoot != null)
        {
            OnShoot();
        }
    }
    public void ShootFalse()
    {
        particleShoot.SetActive(false);
    }
    public void Reload()
    {
        bullet = 5;
        Mag = Mag - difençaBullet;
        dialogueControl.GetBullets(bullet, Mag);
        animator.SetBool("PressR", false);
    }
}
