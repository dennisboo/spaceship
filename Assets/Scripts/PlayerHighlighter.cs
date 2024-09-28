using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerHighlighter : NetworkBehaviour
{
    GameObject[] Players;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        if(!IsOwner)
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(!IsOwner)
        {
            return;
        }
       Players = GameObject.FindGameObjectsWithTag("Player");
        
    }
    private void OnGUI() 
    {
        if(!IsOwner)
        {
            return;
        }
        if(cam == null)
        {
            cam = GetComponentInChildren<Camera>();
        }
        else
        {
            foreach(GameObject Player in Players)
            {
                
                Vector2 ScreenCoordinates = cam.WorldToScreenPoint(Player.transform.position);
                Debug.Log(ScreenCoordinates);
                GUI.Label(new Rect(ScreenCoordinates.x,Screen.height-ScreenCoordinates.y,100,100),"Player");
            
            }
        }
        
    }
}
