using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Monster_scavenger : MonoBehaviour
{
    [SerializeField] Transform Player;
    private Animator animator;
    private NavMeshAgent Nav;
    bool timeFim=false;

    int Life = 600;
    bool Vivo = true;





    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Nav= GetComponent<NavMeshAgent>();
        ControlleCamera.OnTimeline+=Move;

        SpawnBullets.OnAtingir += Atingido;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeFim && Vivo)
        {
            Nav.SetDestination(Player.position);
        }else if (!Vivo)
        {
            Nav.SetDestination(transform.position);
        }
        if (Life <= 0)
        {
            Vivo= false;
            Death();
        }
        
    }
    void Attack()
    {
        
        
    }
    public void Move()
    {
        timeFim = true;
        animator.SetBool("Walk", true);
    }
    void Atingido()
    {
        Life -= 15;
        Debug.Log("Foi atingido.");
    }
    void Death()
    {
        animator.SetBool("isDeath", true);
    }



}
