using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using Unity.Netcode;

public class Bullet : NetworkBehaviour
{
    public float damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log((int)SteamClient.SteamId.Value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
