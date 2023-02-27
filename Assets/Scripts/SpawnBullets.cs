using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullets : MonoBehaviour
{

    [SerializeField] GameObject playerBullet;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    
    public void Shoot()
    {
        Instantiate(playerBullet, transform.position, transform.rotation);
     
        
    }
}
