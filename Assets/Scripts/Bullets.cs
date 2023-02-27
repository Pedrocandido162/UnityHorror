using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Bullets : MonoBehaviour
{
    
    private Rigidbody rb;
    public float speed = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.velocity = (transform.forward * speed);
    }
    public void Attack()
    {
        rb.velocity = (transform.forward * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hospital") || collision.gameObject.CompareTag("Villain"))
        {
            Destroy(gameObject);
        }
    }
}
