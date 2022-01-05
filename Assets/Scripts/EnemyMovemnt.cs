using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovemnt : MonoBehaviour
{
    public Transform player;
    public Rigidbody Rb;
    NavMeshAgent enemy;
    int damage = 15;
   public Animator anim;
    float vec;
   
    // Start is called before the first frame update
    void Start()
    {

        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
       
    }

    // Update is called once per frame
    void Update()
    {


        transform.LookAt(player);
        enemy.SetDestination(player.transform.position);
        vec = Vector3.Distance(player.transform.position, transform.position);
        Target.target.minimum_dis = vec;
       
        if (vec<=2)
        {
             enemy.speed = 0;
            Target.target.Playerhealth();
            anim.SetBool("attack", true);
            anim.applyRootMotion = false;
        }
        else 
        { 
         if (vec > 4)
            { anim.SetBool("attack", false);
                enemy.SetDestination(player.transform.position);
                enemy.speed = 1.5f;
                anim.applyRootMotion = true;
            }

        }
    }
   
    

}