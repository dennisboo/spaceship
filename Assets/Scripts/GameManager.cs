using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


using Unity.Netcode;

public class GameManager : NetworkBehaviour

{
    public GameObject projectile;
    public static GameManager instance { get; private set; }
    public Dictionary<int,PlayerInput> Players = new Dictionary <int,PlayerInput>();
    
    

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Rpc(SendTo.Server)]
    public void SpawnProjectileRPC(Vector3 pos, Quaternion rot, Vector3 projectileVector,int ID)
    {
        GameObject Instance = Instantiate(projectile, pos, rot);
        if(IsOwner)
        {
            Instance.GetComponent<Collider>().enabled=false;
        }
        var InstanceNetworkObject = Instance.GetComponent<NetworkObject>();
       InstanceNetworkObject.Spawn();
      //  Physics.IgnoreCollision(Instance.GetComponentInChildren<Collider>(), GetComponentInChildren<Collider>());
        Instance.GetComponent<Rigidbody>().AddForce(projectileVector, ForceMode.VelocityChange);

    }
    public void ClientEntered(ulong clientId)
    {
        Debug.Log("sfs");
    }

}
