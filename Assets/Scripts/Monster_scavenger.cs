using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Monster_scavenger : MonoBehaviour
{
    [SerializeField] Transform Player;
    private Animator animator;
    private NavMeshAgent Nav;
    bool timeFim=false;
    [SerializeField] BoxCollider box;
    int Life = 1000;
    bool Vivo = true;
    public delegate void step(string Quem);
    public static event step OnDeath;

    [SerializeField]Transform player;
    [SerializeField] float areaAttack=3;
 

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
        Vector3 offset = gameObject.transform.position - player.position;
        float DistanciaDoPlayer = offset.magnitude;
        if (DistanciaDoPlayer <= areaAttack)
        {
            Attack();
        }
        else if(DistanciaDoPlayer >= areaAttack)
        {
            OffAttack();
        }
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
       
       animator.SetBool("IdleAttack", true);
       
    }
    private void OffAttack()
    {
        animator.SetBool("IdleAttack", false);
    }
    public void Move()
    {
        timeFim = true;
        animator.SetBool("Walk", true);
        animator.SetBool("IdleAttack", false);
    }
    void Atingido()
    {
        Life -= 15;
        Debug.Log("Vida restante"+ Life);
    }
    void Death()
    {
        animator.SetBool("isDeath", true);
        box.enabled=false;
        Invoke("ChamarMetodoOnDeath", 2);

    }
    void ChamarMetodoOnDeath()
    {
        if (OnDeath != null)
        {
            OnDeath("Vilao");
        }
    }

}
