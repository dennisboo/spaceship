using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float Speed = 4;
    private Vector3 direction;
    public float rotationSpeed = 6;
    private Vector3 rDirection;
    public Camera Cam;
    public override void OnNetworkSpawn()
    {
        if (!IsOwner) Cam.enabled=false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        
        direction = Vector3.zero;
        rDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += transform.forward * -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //direction -= transform.right;
            rDirection = new Vector3(0, -rotationSpeed*Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //direction += transform.right;
            rDirection = new Vector3(0, rotationSpeed*Time.deltaTime, 0);
        }
        transform.Rotate(rDirection);
        transform.position += direction * Speed * Time.deltaTime;
    }
}
