using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log((int)SteamClient.SteamId.Value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
