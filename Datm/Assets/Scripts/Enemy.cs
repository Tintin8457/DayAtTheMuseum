using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
     public GameObject target;
     public NavMeshAgent enemy;
     Animator trex;
     public AudioSource dino;

    // Start is called before the first frame update
    void Start()
    {
        trex = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate distance between trex and caveman
        float distance = Vector3.Distance(target.transform.position, this.gameObject.transform.position);

        //Follow player
        if (distance > 3.0f && distance < 7.0f)
        {
            //transform.position = target.transform.position - this.gameObject.transform.position;
            //Vector3.MoveTowards(transform.position, target.transform.position, 3.0f);
            trex.SetBool("CanMove", true);
            trex.SetBool("IsRoaring", false);
            trex.SetBool("CanAttack", false);
            enemy.destination = target.transform.position;
        }

        //Roar at the player
        else if (distance >= 7.1f && distance <= 7.5f)
        {
            trex.SetBool("IsRoaring", true);
            dino.Play();
        }

        //Return to idle state
        else if (distance >= 8.0f)
        {
            trex.SetBool("CanMove", false);
            trex.SetBool("IsRoaring", false);
        }

        //Attack
        else if (distance < 3.0f)
        {
            trex.SetBool("CanAttack", true);
        }
    }
}
