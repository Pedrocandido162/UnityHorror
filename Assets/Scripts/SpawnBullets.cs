using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnBullets : MonoBehaviour
{

    [SerializeField] GameObject playerBullet;
    [SerializeField] LayerMask Layoso;
    [SerializeField] float DistanciaMax;

    //Eventos
    public delegate void step();
    public static event step OnAtingir;
    void Start()
    {
        Shotgun.OnShoot += Shoot;


    }

   
    
    public void Shoot()
    {
        RaycastHit Hit = new RaycastHit();
        if (Physics.Raycast(transform.position, transform.forward, out Hit, DistanciaMax, Layoso, QueryTriggerInteraction.Ignore))
        {
            Debug.DrawLine(transform.position, Hit.point, Color.green);

                if (Hit.transform.gameObject.CompareTag("Villain"))
                {
                if (OnAtingir != null)
                {
                    OnAtingir();
                }
                }
                


            }
        }


    }

