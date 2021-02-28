using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
     public GameObject target;
     public NavMeshAgent enemy;
     Animator trex;

    // Start is called before the first frame update
    void Start()
    {
        trex = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Follow player
        float distance = Vector3.Distance(target.transform.position, this.gameObject.transform.position);

        if (distance <= 7.0f)
        {
            //transform.position = target.transform.position - this.gameObject.transform.position;
            //Vector3.MoveTowards(transform.position, target.transform.position, 3.0f);
            trex.SetBool("CanMove", true);
            enemy.destination = target.transform.position;
        }

        //Return to idle state
        else if (distance > 7.0f)
        {
            trex.SetBool("CanMove", false);
        }
    }
}
