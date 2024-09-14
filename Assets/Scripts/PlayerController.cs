using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
using Steamworks;
using TMPro;

public class PlayerController : NetworkBehaviour
{
    public ulong id;
    public float currentHealth = 100f;
    private Ship ship;
    public float speed;
    public float rotationSpeed;
    public GameObject button;
    public TextMeshProUGUI healthText;

    private Vector3 direction;
    private Vector3 rDirection;
    
    public GameObject Projectile;
    public float maxHealth = 100;
    
    public float ShootDelay;
    public float Damage;
    private bool CanShoot = true;
    private int CannonIndex;
    public bool IsHoldingDownShoot = false;
    public float projectileSpeed = 5;
    public bool CanMove = false;
    

    public override void OnNetworkSpawn()
    {
        ship = GetComponentInChildren<Ship>();
        StartCoroutine(wait());
        IEnumerator wait()
        {
            yield return new WaitForSeconds(1);
            ChooseShip(GameManager.instance.SelectedShip);
            button.SetActive(true);
        }
        
        ModifyHealth(0);
        
        if (!IsOwner)
        {
            
            button.SetActive(false);
            
            healthText.enabled = false;
            ship = GetComponentInChildren<Ship>();
            ship.Cam.enabled = false;
            AudioListener[] listeners = GetComponentsInChildren<AudioListener>();
            foreach (AudioListener listener in listeners)
            {
                listener.enabled = false;
            } 
        }
        else
        {
            transform.position = GameObject.FindWithTag("Spawnpoint").transform.position;
            
        }

    }
    public void OnReadyButtonPress()
    {
        ActivatePlayer();
        
    }
    public void InitializePlayer()
    {
        if(!IsOwner)
        {
            
        }
        
    }
    public void ActivatePlayer()
    {
        
        if(!IsOwner)
        {
            
        }
        else
        {
            CanMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            button.SetActive(false);
        }

        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner || !CanMove) return;

        direction = transform.forward;

        Vector3 HorizontalRotationVector = new Vector3(0,rDirection.x,0) * rotationSpeed ;
        Vector3 VerticalRotationVector = new Vector3(-rDirection.y,0,0) * rotationSpeed ;

        transform.Rotate(VerticalRotationVector);
        transform.Rotate(HorizontalRotationVector, Space.World);
        transform.Translate(direction*speed*Time.deltaTime,Space.World);
        //s
        
    }
    public void OnRotation(InputAction.CallbackContext context)
    {
        if(!IsOwner || !CanMove)
        {
            return;
        }
        Vector3 NewRotation = context.ReadValue<Vector3>();
        rDirection = NewRotation;
        


    }
    public void OnShoot(InputAction.CallbackContext Context)
    {
        if(!IsOwner || !CanMove)
        {
            return;
        }
        
        if (Context.performed)
        {
            IsHoldingDownShoot = true;
            if(CanShoot){
                StartCoroutine(ShootCouroutine());
            }
           
            
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
            CanShoot=false;
            Shoot();
            yield return new WaitForSeconds(ShootDelay);
            CanShoot=true;
        }
       
    }
    public void Shoot()
    {
        if(!IsOwner || !CanMove)
        {
            return;
        }
        Transform shootspot = ship.muzzles[CannonIndex];
        
        GameManager.instance.SpawnProjectileRPC(shootspot.position,shootspot.rotation,Damage,shootspot.forward*projectileSpeed, this.NetworkObjectId);
       
        CannonIndex += 1;
        if (CannonIndex >= ship.muzzles.Length)
        {
            CannonIndex = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!IsOwner || !CanMove)
        {
            return;
        }
        Debug.Log("sds");
        if(collision.collider.CompareTag("Floor"))
        {
            Debug.Log("asg"); GameManager.instance.DamagePlayerRPC(this.NetworkObjectId, 100);
        }
        if (collision.collider.GetComponent<Bullet>() != null)
        {
            Debug.Log("ouch!");
            GameManager.instance.DamagePlayerRPC(this.NetworkObjectId, collision.collider.GetComponent<Bullet>().damage);
        }
    }
    public void ModifyHealth(float amount)
    {
        currentHealth += amount;
        if(currentHealth <= 0)
        {
            transform.position = GameObject.FindWithTag("Spawnpoint").transform.position;
            transform.rotation = Quaternion.identity;
            currentHealth = maxHealth;
        }
        healthText.text = "Health: " + currentHealth.ToString();
    }
    public void CopyShip()
    {
        speed = ship.speed;
        maxHealth = ship.maxHealth;
        Damage = ship.attack * 0.1f;
        currentHealth = maxHealth;
        ShootDelay = 60f/ship.shootSpeed;
        projectileSpeed = ship.projectileSpeed;
        ModifyHealth(0);
    }
    public void ChooseShip(int ShipNumber)
    {
        GameManager.instance.ChangeShipRPC(this.NetworkObjectId,ShipNumber);
        ship = GetComponentInChildren<Ship>();
        CopyShip();
    }

}
