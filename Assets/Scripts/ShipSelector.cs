using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelector : MonoBehaviour
{
    public List<Ship> ships;
    public StatsDisplay statsDisplay;

    public int currentShipSelection{ get; private set; }
    void Start()
    {
        
    }


    public void SelectShip()
    {
        Ship ship =   ships[currentShipSelection];
        statsDisplay.SetData(ship);
        ship.SelectedAnimation();
    }
    
    public void NextShip()
    {
        currentShipSelection += 1;
        Ship ship = ships[currentShipSelection];
        statsDisplay.SetData(ship);
    }

    public void PreviousShip()
    {
        currentShipSelection -= 1;
        Ship ship = ships[currentShipSelection];
        statsDisplay.SetData(ship);
    }


    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
