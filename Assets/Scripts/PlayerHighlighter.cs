using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHighlighter : MonoBehaviour
{
    GameObject[] Players;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        
    }
    private void OnGUI() 
    {
        foreach(GameObject Player in Players)
        {
            Vector2 ScreenCoordinates = Camera.main.WorldToScreenPoint(Player.transform.position);
            GUI.Label(new Rect(10,10,ScreenCoordinates.x,ScreenCoordinates.y),"BadGuy");
        }
    }
}
