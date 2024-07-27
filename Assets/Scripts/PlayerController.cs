using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : NetworkBehaviour
{
    public Ship ship;
    public float speed;
    public float rotationSpeed;

    private Vector3 direction;
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

        direction = ship.transform.forward;

        Vector3 RotationVector = new Vector3(-rDirection.y,rDirection.x,-rDirection.z) * rotationSpeed * Time.deltaTime;
       
        //PITCH
      //  if (Input.GetKey(KeyCode.W))
        //{
           // rDirection += new Vector3(-rotationSpeed * Time.deltaTime, 0, 0);
       // }
///if (Input.GetKey(KeyCode.S))
       // {
            //rDirection += new Vector3(rotationSpeed * Time.deltaTime, 0, 0);
        //}
        //ROLL
       // if (Input.GetKey(KeyCode.A))
       // {
          //  rDirection += new Vector3(0, 0, -rotationSpeed * Time.deltaTime);
      //  }
      //  if (Input.GetKey(KeyCode.D))
      //  {
       //     rDirection += new Vector3(0, 0, rotationSpeed * Time.deltaTime);
       // }
        //YAW
       // if (Input.GetKey(KeyCode.E))
      //  {
        //    rDirection += new Vector3(0, rotationSpeed * 0.7f * Time.deltaTime, 0);
       // }
      //  if (Input.GetKey(KeyCode.Q))
       // {
       //     rDirection += new Vector3(0, -rotationSpeed* 0.7f * Time.deltaTime, 0);
       // }


        ship.transform.Rotate(RotationVector);
        transform.position += direction * speed * Time.deltaTime;
        
    }
    public void OnRotation(InputAction.CallbackContext context)
    {
        Vector3 NewRotation = context.ReadValue<Vector3>();
        rDirection = NewRotation;
        Debug.Log("sds");


    }
}
