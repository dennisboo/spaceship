using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelector : MonoBehaviour
{
    public List<Ship> ships;

    private int currentShipSelection;


    public void SelectShip()
    {
        Ship ship =   ships[currentShipSelection];
        ship.SelectedAnimation();
    }
    
    public void NextShip()
    {
        currentShipSelection += 1;
    }

    public void PreviousShip()
    {
        currentShipSelection -= 1;
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
