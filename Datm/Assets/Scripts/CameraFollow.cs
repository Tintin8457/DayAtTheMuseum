using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    //public float adjust = 1f;
    Vector3 offset;
    public float rotateSpeed = 4f;

    void Start()
    {
        offset = player.transform.position - transform.position;
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        //Look around
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        player.transform.Rotate(0, horizontal, 0);

        //Follow the player and move camera
        float aimedAngle = player.transform.eulerAngles.y;

        Quaternion rotation = Quaternion.Euler(0,aimedAngle,0);
        transform.position = player.transform.position - (rotation * offset);
        transform.LookAt(player.transform);
    }
}
