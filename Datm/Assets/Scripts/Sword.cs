using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void MoveToGrip()
    // {
    //     transform.position = new Vector3(-0.0017f, 0.0014f, 0.01f);
    // }

    //Hit enemy
    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            Destroy(hit.gameObject);
        }
    }
}
