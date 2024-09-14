using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using Unity.Netcode;

public class Bullet : MonoBehaviour
{
    public float damagemultiplier = 1;
    public float damage = 0;
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
