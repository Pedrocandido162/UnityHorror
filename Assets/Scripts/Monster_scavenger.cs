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





    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Nav= GetComponent<NavMeshAgent>();
        ControlleCamera.OnTimeline+=Move;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeFim)
        {
            Nav.SetDestination(Player.position);
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



}
