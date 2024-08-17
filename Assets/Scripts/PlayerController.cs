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
    public GameObject Projectile;
    public Transform[] muzzles;
    public float ShootDelay;
    private bool CanShoot = true;
    private int CannonIndex;
    public bool IsHoldingDownShoot = false;
    public float projectileSpeed = 5;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
           
            Cam.enabled = false;
            
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            transform.position = GameObject.FindWithTag("Spawnpoint").transform.position;
        }

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

        Vector3 HorizontalRotationVector = new Vector3(0,rDirection.x,0) * rotationSpeed * Time.deltaTime;
        Vector3 VerticalRotationVector = new Vector3(-rDirection.y,0,0) * rotationSpeed * Time.deltaTime;

        ship.transform.Rotate(VerticalRotationVector);
        ship.transform.Rotate(HorizontalRotationVector, Space.World);
        ship.transform.Translate(direction*speed*Time.deltaTime);
        //s
        
    }
    public void OnRotation(InputAction.CallbackContext context)
    {
        if(!IsOwner)
        {
            return;
        }
        Vector3 NewRotation = context.ReadValue<Vector3>();
        rDirection = NewRotation;
        


    }
    public void OnShoot(InputAction.CallbackContext Context)
    {
        if(!IsOwner)
        {
            return;
        }
        
        if (Context.performed)
        {
            IsHoldingDownShoot = true;
            StartCoroutine(ShootCouroutine());

            
        }
        else if (Context.canceled)
        {
            IsHoldingDownShoot = false;
        }

    }

    IEnumerator ShootCouroutine()
    {
        
        while (IsHoldingDownShoot)
        {
            Shoot();
            yield return new WaitForSeconds(ShootDelay);
        }
       
    }
    public void Shoot()
    {
        if(!IsOwner)
        {
            return;
        }
        Transform shootspot = muzzles[CannonIndex];
        
        GameObject Instance = Instantiate(Projectile, shootspot.position, shootspot.rotation);
        Physics.IgnoreCollision(Instance.GetComponentInChildren<Collider>(), GetComponentInChildren<Collider>());
        Instance.GetComponent<Rigidbody>().AddForce(shootspot.forward * projectileSpeed, ForceMode.VelocityChange);
        CannonIndex += 1;
        if (CannonIndex >= muzzles.Length)
        {
            CannonIndex = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!IsOwner)
        {
            return;
        }
        Debug.Log("sds");
        if(collision.collider.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
