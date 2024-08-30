using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


using Unity.Netcode;

public class GameManager : NetworkBehaviour

{
    public GameObject projectile;
    public static GameManager instance { get; private set; }

    
    

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
    [Rpc(SendTo.Everyone)]
    public void SpawnProjectileRPC(Vector3 pos, Quaternion rot, Vector3 projectileVector,ulong id)
    {
        GameObject Instance = Instantiate(projectile, pos, rot);

        /* var InstanceNetworkObject = Instance.GetComponent<NetworkObject>();
        InstanceNetworkObject.Spawn();
        if(!PlayerObject.TryGet(out NetworkObject Netobject)){

        }*/
        Physics.IgnoreCollision(Instance.GetComponentInChildren<Collider>(),
        NetworkManager.SpawnManager.SpawnedObjects[id].GetComponentInChildren<Collider>());
        Instance.GetComponent<Rigidbody>().AddForce(projectileVector, ForceMode.VelocityChange);

    }
    [Rpc(SendTo.Everyone)]
    public void DamagePlayerRPC(ulong id, float amount)
    {
        NetworkManager.SpawnManager.SpawnedObjects[id].GetComponent<PlayerController>().ModifyHealth(-amount);
    }
    [Rpc(SendTo.NotServer)]
    public void DisableCollisionRPC(NetworkObjectReference PlayerObject)
    {


    }
    public void ClientEntered(ulong clientId)
    {
        Debug.Log("sfs");
    }

}
