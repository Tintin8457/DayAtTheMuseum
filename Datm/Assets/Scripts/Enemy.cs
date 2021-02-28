using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
     public GameObject target;
     public NavMeshAgent enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Follow player
        float distance = Vector3.Distance(target.transform.position, this.gameObject.transform.position);

        if (distance <= 5.0f)
        {
            //transform.position = target.transform.position - this.gameObject.transform.position;
            //Vector3.MoveTowards(transform.position, target.transform.position, 3.0f);
            enemy.destination = target.transform.position;
        }
    }
}
