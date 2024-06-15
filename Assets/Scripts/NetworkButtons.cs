using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class NetworkButtons : MonoBehaviour
{
    public GameObject mainMenuCamera;
    public void HostGame()
    {
        NetworkManager.Singleton.StartHost();
        mainMenuCamera.SetActive(false);
        gameObject.SetActive(false);
        
    }
    public void JoinGame()
    {
        NetworkManager.Singleton.StartClient();
        mainMenuCamera.SetActive(false);
        gameObject.SetActive(false);
    }    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
